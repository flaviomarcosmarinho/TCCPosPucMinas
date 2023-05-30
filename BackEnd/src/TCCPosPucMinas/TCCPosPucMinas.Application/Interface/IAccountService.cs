using Microsoft.AspNetCore.Identity;
using TCCPosPucMinas.Application.BusinessRule;

namespace TCCPosPucMinas.Application.Interface
{
    public interface IAccountService
    {
        Task <bool> UserExists (string userName);

        Task<UserUpdateService> GerUserByUserNameAsync(string userName);

        Task<SignInResult> CheckUserPasswordAsync(UserUpdateService userUpdateService, string password);

        Task<UserService> CreateAccountAsync(UserService userService);

        Task<UserUpdateService> UpdateAccount(UserUpdateService userUpdateService);
    }
}
