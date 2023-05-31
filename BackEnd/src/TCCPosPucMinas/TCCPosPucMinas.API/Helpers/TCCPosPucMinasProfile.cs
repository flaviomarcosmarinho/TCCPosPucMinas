using AutoMapper;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Domain.Identity;

namespace TCCPosPucMinas.API.Helpers
{
    public class TCCPosPucMinasProfile : Profile
    {
        public TCCPosPucMinasProfile()
        {
            CreateMap<User, UserService>().ReverseMap();
            CreateMap<User, UserLoginService>().ReverseMap();
            CreateMap<User, UserUpdateService>().ReverseMap();
        }
    }
}
