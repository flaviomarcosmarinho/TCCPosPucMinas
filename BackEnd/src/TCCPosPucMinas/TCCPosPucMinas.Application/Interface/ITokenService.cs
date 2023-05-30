using TCCPosPucMinas.Application.BusinessRule;

namespace TCCPosPucMinas.Application.Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateService userUpdateService);
    }
}
