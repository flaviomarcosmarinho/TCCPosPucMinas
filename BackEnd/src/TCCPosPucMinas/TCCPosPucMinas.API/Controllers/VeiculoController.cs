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
        public async Task<ActionResult<Veiculo>> GetById(int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculoByIdAsync(id);
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
                var veiculos = await _veiculoService.GetAllVeiculoByMarcaAsync(marca);
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
        public async Task<IActionResult> Post(Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.AddVeiculo(model);
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
        public async Task<IActionResult> Put(int id, Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoService.UpdateVeiculo(id, model);
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
                return await _veiculoService.DeleteVeiculo(id) ?
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