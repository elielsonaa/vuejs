using System.Threading.Tasks;
using controlvac.Data;
using controlvac.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace controlvac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        public IRepository _repo { get; }
        public PacienteController(IRepository repo)
        {
            _repo = repo; //Injetando repositório
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _repo.GetPacientesAsync();
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de paciente!");
            }
        }
        [HttpGet("{PacienteId}")]
        public async Task<IActionResult> Get(int PacienteId)
        {
            try
            {
                var res = await _repo.GetPacienteByIdAsync(PacienteId);
                return Ok(res);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao buscar informaçoes de paciente!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Paciente paciente)
        {
            try
            {
                _repo.Add(paciente);
                if(await _repo.SaveAllAsync()){
                    return Created($"/api/paciente/{paciente.Id}", paciente);
                }
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao enviar informaçoes de paciente!");
            }
            return BadRequest();
        }
        [HttpPut("{PacienteId}")]
        public async Task<IActionResult> Put(int PacienteId, Paciente model)
        {
            try
            { 
                //Verifica se existe o paciente antes de alterar
                var paciente = await _repo.GetPacienteByIdAsync(PacienteId);
                if(paciente == null) return NotFound();
                _repo.Update(model);
                if (await _repo.SaveAllAsync()){
                    paciente = await _repo.GetPacienteByIdAsync(PacienteId);
                    return Created($"/api/paciente/{paciente.Id}", paciente);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar informaçoes de paciente!");
            }
            return BadRequest();
        }
        [HttpDelete("{PacienteId}")]
        public async Task<IActionResult> Delete(int PacienteId)
        {
            try
            {
                var paciente = await _repo.GetPacienteByIdAsync(PacienteId);
                if (paciente == null) return NotFound();
                _repo.Delete(paciente);
                if (await _repo.SaveAllAsync())
                {
                    return Ok($"Paciente excluído com sucesso!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir informaçoes de paciente!");
            }
            return BadRequest();
        }
    }
}