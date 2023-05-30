using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Identity;
using TCCPosPucMinas.Persistence.Interface;

namespace TCCPosPucMinas.Application.BusinessRule
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;

        public AccountService(UserManager<User> userManager, 
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IUserPersist userPersist)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
            this._userPersist = userPersist;
        }

        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateService userUpdateDto, string password)
        {
            try
            {
                var user = await this._userManager.Users.SingleOrDefaultAsync(user => user.UserName.ToLower().Equals(userUpdateDto.UserName.ToLower()));                
                return await this._signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha. Erro: {ex.Message}");
            }
        }

        public async Task<UserService> CreateAccountAsync(UserService userService)
        {
            try
            {
                var user = this._mapper.Map<User>(userService);
                var result = await this._userManager.CreateAsync(user, userService.Password);

                if (result.Succeeded)
                {
                    var userToReturn = this._mapper.Map<UserService>(user);
                    return userToReturn;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar conta de usuário. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateService> GerUserByUserNameAsync(string username)
        {
            try
            {
                var user = await this._userPersist.GetUserByUserNameAsync(username);
                if(user == null)
                {
                    return null;
                }

                var userToUpdateService = this._mapper.Map<UserUpdateService>(user);
                return userToUpdateService;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar encontrar usuário por Username. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateService> UpdateAccount(UserUpdateService userUpdateService)
        {
            try
            {
                var user = await this._userPersist.GetUserByUserNameAsync(userUpdateService.UserName);
                if (user == null) return null;

                this._mapper.Map(userUpdateService, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await this._userManager.ResetPasswordAsync(user, token, userUpdateService.Password);

                this._userPersist.Update<User>(user);

                if(await this._userPersist.SaveChangesAsync())
                {
                    var userRetorno = await this._userPersist.GetUserByUserNameAsync(user.UserName);

                    return this._mapper.Map<UserUpdateService>(userRetorno);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar conta de usuário. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            try
            {
                return await this._userManager.Users.AnyAsync(u => u.UserName.ToLower().Equals(userName.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar se usuário existe. Erro: {ex.Message}");
            }
        }
    }
}
