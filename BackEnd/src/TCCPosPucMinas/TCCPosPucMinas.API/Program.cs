using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Persistence;
using TCCPosPucMinas.Persistence.Interface;
using TCCPosPucMinas.Persistence.Repositoty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TCCPosPucMinasContext>(
        context => context.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//Adicionando as configurações de injeção de dependência
builder.Services.AddScoped<IMarcaService, MarcaService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
builder.Services.AddScoped<IVeiculoPersist, VeiculoPersistence>();
builder.Services.AddScoped<IMarcaPersist, MarcaPersistence>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
