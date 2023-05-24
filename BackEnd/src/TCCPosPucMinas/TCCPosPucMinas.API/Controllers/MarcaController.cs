using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.Application.Interface;
using TCCPosPucMinas.Domain.Models;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            this._marcaService = marcaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marcas = await _marcaService.GetAllMarcasAsync();
                if (marcas == null)
                {
                    return NotFound("Nenhuma marca encontrada!");
                }

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar as marcas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetById(int id)
        {
            try
            {
                var marca = await _marcaService.GetMarcaByIdAsync(id);
                if (marca == null)
                {
                    return NotFound("Marca não encontrada!");
                }

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar a marca com id: {id}. Erro: {ex.Message}");
            }
        }        

        [HttpPost]
        public async Task<IActionResult> Post(Marca model)
        {
            try
            {
                var Marca = await _marcaService.AddMarca(model);
                if (Marca == null)
                {
                    return BadRequest("Erro ao adicionar marca!");
                }

                return Ok(Marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar marca. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Marca model)
        {
            try
            {
                var Marca = await _marcaService.UpdateMarca(id, model);
                if (Marca == null)
                {
                    return BadRequest("Erro ao atualizar marca!");
                }

                return Ok(Marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar a marca. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _marcaService.DeleteMarca(id) ?
                       Ok("Marca removida com sucesso!") :
                       BadRequest("Não foi possível deletar a marca!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar a marca. Erro: {ex.Message}");
            }
        }
    }
}
