using System.Threading.Tasks;
using controlvac.Data;
using controlvac.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinacaoController : ControllerBase
    {
        public IRepository _repo { get; }
        public VacinacaoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _repo.GetVacinacaoAsync();
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de vacinacao!");
            }
        }
        [HttpGet("{VacinacaoId}")]
        public async Task<IActionResult> Get( int VacinacaoId)
        {
            try
            {
                var res = await _repo.GetVacinacaoAsync();
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de vacinacao!");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vacinacao model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveAllAsync())
                {
                    return Created($"/api/vacinacao/{model.Id}", model);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao enviar informaçoes de vacinacao!");
            }
            return BadRequest();
        }
        [HttpPut("{VacinacaoId}")]
        public async Task<IActionResult> Put(int VacinacaoId)
        {
            try
            {
                var vacinacao = await _repo.GetVacinacaoByIdAsync(VacinacaoId);
                if (vacinacao == null) return NotFound();
                _repo.Update(vacinacao);
                if (await _repo.SaveAllAsync())
                {
                    vacinacao = await _repo.GetVacinacaoByIdAsync(VacinacaoId);
                    return Created($"/api/vacinacao/{vacinacao.Id}", vacinacao);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar informaçoes de vacinacao!");
            }
            return NotFound();
        }
        [HttpDelete("{VacinacaoId}")]
        public async Task<IActionResult> Delete(int VacinacaoId)
        {
            try
            {
                var vacinacao = await _repo.GetVacinacaoByIdAsync(VacinacaoId);
                if( vacinacao == null) return NotFound();
                _repo.Delete(vacinacao);
                if( await _repo.SaveAllAsync())
                {
                    return Ok($"Vacinação excluída com sucesso!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir informaçoes de vacinacao!");
            }
            return NotFound();
        }
    }
}