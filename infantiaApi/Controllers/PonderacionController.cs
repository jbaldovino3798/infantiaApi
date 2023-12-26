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
            try
            {
                return Ok(await _ponderacionRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpGet("[action]/{idPonderacion}")]
        public async Task<IActionResult> GetPonderacion(int idPonderacion)
        {
            try
            {
                return Ok(await _ponderacionRepository.GetPonderacion(idPonderacion));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePonderacion([FromBody] Ponderacion ponderacion)
        {
            if (ponderacion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _ponderacionRepository.InsertPonderacion(ponderacion);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePonderacion([FromBody] Ponderacion ponderacion)
        {
            if (ponderacion == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(await _ponderacionRepository.UpdatePonderacion(ponderacion));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]/{idPonderacion}")]
        public async Task<IActionResult> DeletePonderacion(int idPonderacion)
        {
            try
            {
                return Ok(await _ponderacionRepository.DeletePonderacion(idPonderacion = idPonderacion));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
