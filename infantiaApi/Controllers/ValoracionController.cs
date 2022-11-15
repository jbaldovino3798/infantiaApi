using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoracionController : ControllerBase
    {
        private readonly IValoracion _valoracionRepository;

        public ValoracionController(IValoracion valoracionRepository)
        {
            _valoracionRepository = valoracionRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _valoracionRepository.GetAll());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateTemporalidad([FromBody] Valoracion valoracion)
        {
            if (valoracion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _valoracionRepository.InsertValoracion(valoracion);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateTemporalidad([FromBody] Valoracion valoracion)
        {
            if (valoracion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _valoracionRepository.UpdateValoracion(valoracion);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteTemporalidad(int idValoracion)
        {
            await _valoracionRepository.DeleteValoracion(new Valoracion { idValoracion = idValoracion });
            return NoContent();
        }
    }
}
