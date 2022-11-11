using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly IPregunta _preguntaRepository;

        public PreguntaController(IPregunta preguntaRepository)
        {
            _preguntaRepository = preguntaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _preguntaRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreatePregunta([FromBody] Pregunta pregunta)
        {
            if (pregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _preguntaRepository.InsertPregunta(pregunta);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePregunta([FromBody] Pregunta pregunta)
        {
            if (pregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _preguntaRepository.UpdatePregunta(pregunta);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePregunta(int idPregunta)
        {
            await _preguntaRepository.DeletePregunta(new Pregunta { idPregunta = idPregunta });
            return NoContent();
        }
    }
}
