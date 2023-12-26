using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionTipoPreguntaController : ControllerBase
    {
        private readonly IConfiguracionTipoPregunta _configuracionTipoPreguntaRepository;

        public ConfiguracionTipoPreguntaController(IConfiguracionTipoPregunta configuracionTipoPreguntaRepository)
        {
            _configuracionTipoPreguntaRepository = configuracionTipoPreguntaRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _configuracionTipoPreguntaRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpGet("[action]/{idTipoPregunta}")]
        public async Task<IActionResult> GetAllbyTipoPregunta(int idTipoPregunta)
        {
            return Ok(await _configuracionTipoPreguntaRepository.GetAllbyTipoPregunta(idTipoPregunta));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateConfiguracionTipoPregunta([FromBody] ConfiguracionTipoPregunta configuracionTipoPregunta)
        {
            if (configuracionTipoPregunta == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _configuracionTipoPreguntaRepository.InsertConfiguracionTipoPregunta(configuracionTipoPregunta);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateConfiguracionTipoPregunta([FromBody] ConfiguracionTipoPregunta configuracionTipoPregunt)
        {
            if (configuracionTipoPregunt == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _configuracionTipoPreguntaRepository.UpdateConfiguracionTipoPregunta(configuracionTipoPregunt));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteConfiguracionTipoPregunta(int idConfiguracion)
        {
            try
            {
                return Ok(await _configuracionTipoPreguntaRepository.DeleteConfiguracionTipoPregunta(idConfiguracion));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
