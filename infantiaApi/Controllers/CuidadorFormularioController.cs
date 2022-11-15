using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadorFormularioController : ControllerBase
    {
        private readonly ICuidadorFormulario _cuidadorFormularioRepository;

        public CuidadorFormularioController(ICuidadorFormulario cuidadorFormularioRepository)
        {
            _cuidadorFormularioRepository = cuidadorFormularioRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cuidadorFormularioRepository.GetAll());
        }

        [HttpGet("[action]/{cedulaCuidador}/{idFormulario}")]
        public async Task<IActionResult> GetCuidador(int cedulaCuidador, int idFormulario)
        {
            return Ok(await _cuidadorFormularioRepository.GetCuidadorFormulario(cedulaCuidador, idFormulario));
        }

        [HttpGet("[action]/{idFormulario}")]
        public async Task<IActionResult> GetAllbyFormulario(int idFormulario)
        {
            return Ok(await _cuidadorFormularioRepository.GetAllbyFormulario(idFormulario));
        }

        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllbyCuidador(int cedulaCuidador)
        {
            return Ok(await _cuidadorFormularioRepository.GetAllbyCuidador(cedulaCuidador));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCuidador([FromBody] CuidadorFormulario cuidadorFormulario)
        {
            if (cuidadorFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _cuidadorFormularioRepository.InsertCuidadorFormulario(cuidadorFormulario);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCuidador([FromBody] CuidadorFormulario cuidadorFormulario)
        {
            if (cuidadorFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _cuidadorFormularioRepository.UpdateCuidadorFormulario(cuidadorFormulario);
            return NoContent();
        }

        [HttpDelete("[action]/{cedulaCuidador}/{idFormulario}")]
        public async Task<IActionResult> DeleteCuidador(int cedulaCuidador, int idFormulario)
        {
            await _cuidadorFormularioRepository.DeleteCuidadorFormulario(new CuidadorFormulario { 
                cedulaCuidador = cedulaCuidador,
                idFormulario = idFormulario});
            return NoContent();
        }
    }
}
