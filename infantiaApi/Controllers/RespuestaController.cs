using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly IRespuesta _respuestaRepository;

        public RespuestaController(IRespuesta respuestaRepository)
        {
            _respuestaRepository = respuestaRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _respuestaRepository.GetAll());
        }

        [HttpGet("[action]/{idPregunta}")]
        public async Task<IActionResult> GetAllbyPregunta(int idPregunta)
        {
            return Ok(await _respuestaRepository.GetAllbyPregunta(idPregunta));
        }

        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllbyCuidador(int cedulaCuidador)
        {
            return Ok(await _respuestaRepository.GetAllbyCuidador(cedulaCuidador));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePregunta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _respuestaRepository.InsertRespuesta(respuesta);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePregunta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _respuestaRepository.UpdateRespuesta(respuesta);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePregunta(int idRespuesta)
        {
            await _respuestaRepository.DeleteRespuesta(new Respuesta { idRespuesta = idRespuesta });
            return NoContent();
        }
    }
}
