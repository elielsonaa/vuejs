using controlvac.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        public VacinaController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok( new [] { new Vacina(
                    1,
                    "CoronaVac",
                    "Sinovac Biotech",
                    "8979879",
                    new System.DateTime(2022, 12, 24),
                    2,
                    15
                   ),
                   new Vacina(
                    2,
                    "BioNTech",
                    "Pfizer BioNTech",
                    "23124142",
                    new System.DateTime(2022, 12, 13),
                    2,
                    15
                   )
                }

                );
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao buscar informaçoes de vacina!");
            }
        }
        [HttpGet("{VacinaId}")]
        public IActionResult Get(int VacinaId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao buscar informaçoes de vacina!");
            }
        }
        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao enviar informaçoes de vacina!");
            }
        }
        [HttpPut("{VacinaId}")]
        public IActionResult Put(int VacinaId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar informaçoes de vacina!");
            }
        }
        [HttpDelete("{VacinaId}")]
        public IActionResult Delete(int VacinaId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir informaçoes de vacina!");
            }
        }
    }
}