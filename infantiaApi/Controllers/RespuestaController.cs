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
    public class RespuestaController : ControllerBase
    {
        private readonly IRespuesta _respuestaRepository;

        public RespuestaController(IRespuesta respuestaRepository)
        {
            _respuestaRepository = respuestaRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _respuestaRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        /*[HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllbyCuidador(int cedulaCuidador)
        {
            return Ok(await _respuestaRepository.GetAllbyCuidador(cedulaCuidador));
        }*/

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRespuesta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _respuestaRepository.InsertRespuesta(respuesta);
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
        public async Task<IActionResult> UpdateRespuesta([FromBody] Respuesta respuesta)
        {
            if (respuesta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _respuestaRepository.UpdateRespuesta(respuesta));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteRespuesta(int idRespuesta)
        {
            try
            {
                return Ok(await _respuestaRepository.DeleteRespuesta(new Respuesta { idRespuesta = idRespuesta }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
