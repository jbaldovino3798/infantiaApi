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
            return Ok(await _municipioRepository.GetAll());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateMunicipio([FromBody] Municipio municipio)
        {
            if (municipio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _municipioRepository.InsertMunicipio(municipio);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMunicipio([FromBody] Municipio municipio)
        {
            if (municipio == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _municipioRepository.UpdateMunicipio(municipio);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMunicipio(string codigoMunicipio)
        {
            await _municipioRepository.DeleteMunicipio(new Municipio { codigoMunicipio = codigoMunicipio });
            return NoContent();
        }

    }
}
