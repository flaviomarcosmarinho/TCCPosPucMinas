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
                    return NotFound("Nenhum veículo encontrado!");
                }

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os veículos. Erro: {ex.Message}");
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
                    return NotFound("Veículo não encontrado!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o veículo com id: {id}. Erro: {ex.Message}");
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
                    return NotFound($"Nenhum veículo da marca {marca} encontrado!");
                }

                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar os veículos da marca: {marca}. Erro: {ex.Message}");
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
                    return BadRequest("Erro ao adicionar veículo!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar o veículo. Erro: {ex.Message}");
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
                    return BadRequest("Erro ao atualizar veículo!");
                }

                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar o veículo. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _veiculoService.DeleteVeiculo(User.GetUserId(), id) ?
                       Ok("Veículo removido com sucesso!") :
                       BadRequest("Não foi possível deletar o veículo!");                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar veículo. Erro: {ex.Message}");
            }
        }
    }

}