using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPreguntaController : ControllerBase
    {
        private readonly ITipoPregunta _tipoPreguntaRepository;

        public TipoPreguntaController(ITipoPregunta tipoPreguntaRepository)
        {
            _tipoPreguntaRepository = tipoPreguntaRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _tipoPreguntaRepository.GetAll());
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

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTipoPregunta([FromBody] TipoPregunta tipoPregunta)
        {
            if (tipoPregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _tipoPreguntaRepository.InsertTipoPregunta(tipoPregunta);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTipoPregunta([FromBody] TipoPregunta tipoPregunta)
        {
            if (tipoPregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _tipoPreguntaRepository.UpdateTipoPregunta(tipoPregunta));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTipoPregunta(int idTipoPregunta)
        {
            try
            {
                return Ok(await _tipoPreguntaRepository.DeleteTipoPregunta( idTipoPregunta));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
