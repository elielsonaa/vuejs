using controlvac.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public PacienteController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { new Paciente(
                    1,
                    "22408420830",
                    "Elielson",
                    "de Azevedo Andrade",
                    "973820",
                    new System.DateTime(1983, 08, 09),
                    EComorbidade.Nao,
                    "Capivari",
                    "SP"
                   ),
                  new Paciente(
                    2,
                    "2289658984",
                    "Marcio",
                    "Augusto dos Santos",
                    "123245",
                    new System.DateTime(1983, 08, 09),
                    EComorbidade.Nao,
                    "Capivari",
                    "SP"
                   )
                });
        }
        [HttpGet("{PacienteId}")]
        public IActionResult Get(int PacienteId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de paciente!");
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao enviar informaçoes de paciente!");
            }
        }
        [HttpPut("{PacienteId}")]
        public IActionResult Put(int PacienteId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar informaçoes de paciente!");
            }
        }
        [HttpDelete("{PacienteId}")]
        public IActionResult Delete(int PacienteId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir informaçoes de paciente!");
            }
        }
    }
}