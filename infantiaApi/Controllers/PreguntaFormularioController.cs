using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaFormularioController : ControllerBase
    {
        private readonly IPreguntaFormulario _preguntaFormularioRepository;

        public PreguntaFormularioController(IPreguntaFormulario preguntaFormularioRepository)
        {
            _preguntaFormularioRepository = preguntaFormularioRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _preguntaFormularioRepository.GetAll());
        }

        /*[HttpGet("[action]/{cedulaCuidador}/{idFormulario}")]
        public async Task<IActionResult> GetCuidador(int cedulaCuidador, int idFormulario)
        {
            return Ok(await _preguntaFormularioRepository.GetCuidadorFormulario(cedulaCuidador, idFormulario));
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
        */
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePreguntaFormulario([FromBody] PreguntaFormulario preguntaFormulario)
        {
            if (preguntaFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _preguntaFormularioRepository.InsertPreguntaFormulario(preguntaFormulario);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCuidador([FromBody] PreguntaFormulario preguntaFormulario)
        {
            if (preguntaFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _preguntaFormularioRepository.UpdatePreguntaFormulario(preguntaFormulario);
            return NoContent();
        }

        [HttpDelete("[action]/{idPregunta}/{idFormulario}")]
        public async Task<IActionResult> DeleteCuidador(int idPregunta, int idFormulario)
        {
            await _preguntaFormularioRepository.DeletePreguntaFormulario(new PreguntaFormulario
            { 
                idPregunta = idPregunta,
                idFormulario = idFormulario});
            return NoContent();
        }
    }
}
