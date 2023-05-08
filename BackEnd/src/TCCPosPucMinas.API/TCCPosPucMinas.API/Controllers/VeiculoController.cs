using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.API.Data;
using TCCPosPucMinas.API.Models;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly DataContext context;

        public VeiculoController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Veiculo> Get()
        {
            return context.Veiculos;
        }

        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetById(int id)
        {
             var veiculo = context.Veiculos.FirstOrDefault(v => v.Id == id);
            
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