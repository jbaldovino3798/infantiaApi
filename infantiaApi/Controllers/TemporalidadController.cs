using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporalidadController : ControllerBase
    {
        private readonly ITemporalidad _temporalidadRepository;

        public TemporalidadController(ITemporalidad temporalidadRepository)
        {
            _temporalidadRepository = temporalidadRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _temporalidadRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTemporalidad([FromBody] Temporalidad temporalidad)
        {
            if (temporalidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _temporalidadRepository.InsertTemporalidad(temporalidad);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTemporalidad([FromBody] Temporalidad temporalidad)
        {
            if (temporalidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _temporalidadRepository.UpdateTemporalidad(temporalidad));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTemporalidad(int idTemporalidad)
        {
            try
            {
                return Ok(await _temporalidadRepository.DeleteTemporalidad(new Temporalidad { idTemporalidad = idTemporalidad }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
