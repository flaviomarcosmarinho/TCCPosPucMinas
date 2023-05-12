using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.Domain.Models;
using TCCPosPucMinas.Persistence;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly TCCPosPucMinasContext _context;

        public VeiculoController(TCCPosPucMinasContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Veiculo> Get()
        {
            return _context.Veiculos;
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetById(int id)
        {
             var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);
            
            if(veiculo != null)
            {
                return Ok(veiculo);
            }
            else
            {
                return NotFound("Veículo não encontrado!");
            }
        }
    }

}