using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            this._veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var veiculos = await _veiculoService.GetAllVeiculosAsync();
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
        public async Task<ActionResult<Veiculo>> GetById(int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
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
                var veiculos = await _veiculoService.GetAllVeiculoByMarcaAsync(marca);
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
        public async Task<IActionResult> Post(Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.AddVeiculo(model);
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
        public async Task<IActionResult> Put(int id, Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(id, model);
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
                return await _veiculoService.DeleteVeiculo(id) ?
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