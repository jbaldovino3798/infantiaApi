using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipio _municipioRepository;

        public MunicipioController(IMunicipio municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _municipioRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMunicipio([FromBody] Municipio municipio)
        {
            if (municipio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _municipioRepository.InsertMunicipio(municipio);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMunicipio([FromBody] Municipio municipio)
        {
            if (municipio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _municipioRepository.UpdateMunicipio(municipio));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMunicipio(string codigoMunicipio)
        {
            try
            {
                return Ok(await _municipioRepository.DeleteMunicipio(new Municipio { codigoMunicipio = codigoMunicipio }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

    }
}
