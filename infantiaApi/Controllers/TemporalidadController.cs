using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _temporalidadRepository.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTemporalidad([FromBody] Temporalidad temporalidad)
        {
            if (temporalidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _temporalidadRepository.InsertTemporalidad(temporalidad);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTemporalidad([FromBody] Temporalidad temporalidad)
        {
            if (temporalidad == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _temporalidadRepository.UpdateTemporalidad(temporalidad);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTemporalidad(int idTemporalidad)
        {
            await _temporalidadRepository.DeleteTemporalidad(new Temporalidad { idTemporalidad = idTemporalidad });
            return NoContent();
        }
    }
}
