using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinacaoController : ControllerBase
    {
        public VacinacaoController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new object[]{});
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de vacinacao!");
            }
        }
        [HttpGet("{VacinacaoId}")]
        public IActionResult Get( int VacinacaoId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de vacinacao!");
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
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao enviar informaçoes de vacinacao!");
            }
        }
        [HttpPut("{VacinacaoId}")]
        public IActionResult Put(int VacinacaoId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar informaçoes de vacinacao!");
            }
        }
        [HttpDelete("{VacinacaoId}")]
        public IActionResult Delete(int VacinacaoId)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir informaçoes de vacinacao!");
            }
        }
    }
}