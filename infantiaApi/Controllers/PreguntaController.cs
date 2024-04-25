using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaController : ControllerBase
    {
        private readonly IPregunta _preguntaRepository;

        public PreguntaController(IPregunta preguntaRepository)
        {
            _preguntaRepository = preguntaRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _preguntaRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPreguntasNotInFormulario(int idFormulario)
        {
            try
            {
                return Ok(await _preguntaRepository.GetPreguntasNotInFormulario(idFormulario));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePregunta([FromBody] Pregunta pregunta)
        {
            if (pregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _preguntaRepository.InsertPregunta(pregunta);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePregunta([FromBody] Pregunta pregunta)
        {
            if (pregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _preguntaRepository.UpdatePregunta(pregunta));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePregunta(int idPregunta)
        {
            try
            {
                return Ok(await _preguntaRepository.DeletePregunta(new Pregunta { idPregunta = idPregunta }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
