using System.Threading.Tasks;
using controlvac.Data;
using controlvac.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        public IRepository _repo { get;}
        public VacinaController(IRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _repo.GetVacinasAsync();
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao buscar informaçoes de vacina!");
            }
        }
        [HttpGet("{VacinaId}")]
        public async Task<IActionResult> Get(int VacinaId)
        {
            try
            {
                var res = await _repo.GetVacinaByIdAsync(VacinaId);
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao buscar informaçoes de vacina!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Vacina vacina)
        {
            try
            {
                _repo.Add(vacina);
                if (await _repo.SaveAllAsync())
                {
                    return Created($"/api/vacina/{vacina.Id}", vacina);
                }

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao enviar informaçoes de vacina!");
            }
            return BadRequest();
        }
        [HttpPut("{VacinaId}")]
        public async Task<IActionResult> Put(int VacinaId, Vacina model)
        {
            try
            {
                //Verifica se existe o paciente antes de alterar
                var vacina = await _repo.GetVacinaByIdAsync(VacinaId);
                if (vacina == null) return NotFound();
                _repo.Update(model);
                if (await _repo.SaveAllAsync())
                {
                    vacina = await _repo.GetVacinaByIdAsync(VacinaId);
                    return Created($"/api/vacina/{vacina.Id}", vacina);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao atualizar informaçoes de vacina!");
            }
            return BadRequest();
        }
        [HttpDelete("{VacinaId}")]
        public async Task<IActionResult> Delete(int VacinaId)
        {
            try
            {
                var vacina = await _repo.GetVacinaByIdAsync(VacinaId);
                if (vacina == null) return NotFound();
                _repo.Delete(vacina);
                if (await _repo.SaveAllAsync())
                {
                    return Ok($"Vacina excluída com sucesso!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir informaçoes de vacina!");
            }
            return BadRequest();
        }
    }
}