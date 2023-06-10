using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.Application.BusinessRule;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.API.Extensions;

namespace TCCPosPucMinas.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService)
        {
            this._accountService = accountService;
            this._tokenService = tokenService;
        }

        [HttpGet("GetUser")]       
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await this._accountService.GerUserByUserNameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserService userService)
        {
            try
            {
                if (await this._accountService.UserExists(userService.UserName))
                {
                    return BadRequest("Usuário já existe");
                }

                var user = await this._accountService.CreateAccountAsync(userService);
                
                if(user != null)
                {
                    return Ok(user);
                }

                return BadRequest("Não foi possível criar o usuário. Tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar registrar o usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginService userLogin)
        {
            try
            {
                var user = await this._accountService.GerUserByUserNameAsync(userLogin.UserName);
                if(user == null)
                {
                    return Unauthorized("Usuário ou senha inválidos");
                }

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                if(!result.Succeeded)
                {
                    return Unauthorized("Usuário ou senha inválidos");
                }

                return Ok(new
                {
                    userName = user.UserName,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar login. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateService userUpdateService)
        {
            try
            {
                var user = await this._accountService.GerUserByUserNameAsync(User.GetUserName());
                if (user == null)
                {
                    return Unauthorized("Usuário inválido");
                }

                var userReturn = await this._accountService.UpdateAccount(userUpdateService);

                if (userReturn == null)
                {
                    return NoContent();
                }

                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar o usuário. Erro: {ex.Message}");
            }
        }
    }
}
