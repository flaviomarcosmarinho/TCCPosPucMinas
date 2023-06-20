using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.API.Extensions;
using TCCPosPucMinas.Application.Dtos;
using TCCPosPucMinas.Application.Interface;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IAccountService _accountService;

        public VeiculoController(IVeiculoService veiculoService,
                                 IAccountService accountService)
        {
            this._veiculoService = veiculoService;
            this._accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var veiculos = await _veiculoService.GetAllVeiculosAsync(User.GetUserId());
                if (veiculos == null)
                {
                    return NotFound("Nenhum ve�culo encontrado!");
                }

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os ve�culos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDto>> GetById(int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(User.GetUserId(), id);
                if (veiculo == null)
                {
                    return NotFound("Ve�culo n�o encontrado!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o ve�culo com id: {id}. Erro: {ex.Message}");
            }
        }

        [HttpGet("veiculo/{marca}")]
        public async Task<IActionResult> GetByMarca(string marca)
        {
            try
            {
                var veiculos = await _veiculoService.GetAllVeiculoByMarcaAsync(User.GetUserId(), marca);
                if (veiculos == null)
                {
                    return NotFound($"Nenhum ve�culo da marca {marca} encontrado!");
                }

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os ve�culos da marca: {marca}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(VeiculoDto model)
        {
            try
            {                
                var veiculo = await _veiculoService.AddVeiculo(User.GetUserId(), model);
                if (veiculo == null)
                {
                    return BadRequest("Erro ao adicionar ve�culo!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar o ve�culo. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, VeiculoDto model)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(User.GetUserId(), id, model);
                if (veiculo == null)
                {
                    return BadRequest("Erro ao atualizar ve�culo!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o ve�culo. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _veiculoService.DeleteVeiculo(User.GetUserId(), id) ?
                       Ok("Ve�culo removido com sucesso!") :
                       BadRequest("N�o foi poss�vel deletar o ve�culo!");                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar ve�culo. Erro: {ex.Message}");
            }
        }
    }

}