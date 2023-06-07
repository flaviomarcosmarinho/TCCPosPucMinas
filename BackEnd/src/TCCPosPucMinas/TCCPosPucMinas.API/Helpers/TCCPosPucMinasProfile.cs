using AutoMapper;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Domain.Identity;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.API.Helpers
{
    public class TCCPosPucMinasProfile : Profile
    {
        public TCCPosPucMinasProfile()
        {
            CreateMap<Marca, MarcaService>().ReverseMap();
            CreateMap<Veiculo, VeiculoService>().ReverseMap();

            CreateMap<User, UserService>().ReverseMap();
            CreateMap<User, UserLoginService>().ReverseMap();
            CreateMap<User, UserUpdateService>().ReverseMap();
        }
    }
}
