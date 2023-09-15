using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonderacionController : ControllerBase
    {
        private readonly IPonderacion _ponderacionRepository;

        public PonderacionController(IPonderacion ponderacionRepository)
        {
            _ponderacionRepository = ponderacionRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            /*String data = JsonSerializer.Serialize(await _perfilRepository.GetAll());
            return Ok(data);*/
            return Ok(await _ponderacionRepository.GetAll());
        }

        [HttpGet("[action]/{idPonderacion}")]
        public async Task<IActionResult> GetPonderacion(int idPonderacion)
        {
            return Ok(await _ponderacionRepository.GetPonderacion(idPonderacion));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePonderacion([FromBody] Ponderacion ponderacion)
        {
            if (ponderacion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _ponderacionRepository.InsertPonderacion(ponderacion);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePonderacion([FromBody] Ponderacion ponderacion)
        {
            if (ponderacion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ponderacionRepository.UpdatePonderacion(ponderacion);
            return NoContent();
        }

        [HttpDelete("[action]/{idPonderacion}")]
        public async Task<IActionResult> DeletePonderacion(int idPonderacion)
        {
            await _ponderacionRepository.DeletePonderacion(new Ponderacion { idPonderacion = idPonderacion });
            return NoContent();
        }
    }
}
