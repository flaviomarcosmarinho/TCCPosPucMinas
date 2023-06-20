using AutoMapper;
using TCCPosPucMinas.Application.Dtos;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Domain.Identity;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.Application.Helpers
{
    public class TCCPosPucMinasProfile : Profile
    {
        public TCCPosPucMinasProfile()
        {
            CreateMap<Marca, MarcaService>().ReverseMap();
            CreateMap<Veiculo, VeiculoDto>().ReverseMap();

            CreateMap<User, UserService>().ReverseMap();
            CreateMap<User, UserLoginService>().ReverseMap();
            CreateMap<User, UserUpdateService>().ReverseMap();
        }
    }
}
