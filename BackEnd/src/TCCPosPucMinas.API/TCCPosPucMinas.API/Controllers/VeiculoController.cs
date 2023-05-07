using Microsoft.AspNetCore.Mvc;
using TCCPosPucMinas.API.Models;

namespace TCCPosPucMinas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        public VeiculoController()
        {
        }

        [HttpGet]
        public IEnumerable<Veiculo> Get()
        {
            return new Veiculo[]
            {
                new Veiculo()
                {
                    Id = 1,
                    Marca = "Toyota",
                    Modelo = "Corolla",
                    AnoFabricacao = "2008",
                    AnoModelo = "2007",
                    Preco = 35000.00m
                }
            };
        }

    }

}