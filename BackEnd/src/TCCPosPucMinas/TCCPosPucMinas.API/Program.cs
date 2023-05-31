using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Identity;
using TCCPosPucMinas.Persistence;
using TCCPosPucMinas.Persistence.Interface;
using TCCPosPucMinas.Persistence.Repositoty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TCCPosPucMinasContext>(
        context => context.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 4;
})
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddSignInManager<SignInManager<User>>()
    .AddRoleValidator<RoleValidator<Role>>()
    .AddEntityFrameworkStores<TCCPosPucMinasContext>()
    .AddDefaultTokenProviders(); //Sem esta configuração, o reset do token durante o update não funciona.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

builder.Services.AddControllers()
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()) //Configuração para tratar os enum como string no Json.
                )
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = 
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore //Utilizado para resolver o problema de loop infinito entre as entidades no Json
                 );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Procura a classe que está herdando de Profile do Automapper.

//Adicionando as configurações de injeção de dependência
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IVeiculoPersist, VeiculoPersistence>();
builder.Services.AddScoped<IMarcaPersist, MarcaPersistence>();
builder.Services.AddScoped<IUserPersist, UserPersistence>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection(); //Enable the SSL Certificate

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
