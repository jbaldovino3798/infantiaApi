using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

namespace infantiaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfilRepository;

        public PerfilController(IPerfil perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            /*String data = JsonSerializer.Serialize(await _perfilRepository.GetAll());
            return Ok(data);*/
            try
            {
                return Ok(await _perfilRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]/{idPerfil}")]
        public async Task<IActionResult> GetPerfil(int idPerfil)
        {
            try
            {
                return Ok(await _perfilRepository.GetPerfil(idPerfil));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePerfil([FromBody] Perfil perfil)
        {
            if (perfil == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _perfilRepository.InsertPerfil(perfil);
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
        public async Task<IActionResult> UpdatePerfil([FromBody] Perfil perfil)
        {
            if (perfil == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {                
                return Ok(await _perfilRepository.UpdatePerfil(perfil));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpDelete("[action]/{idPerfil}")]
        public async Task<IActionResult> DeletePerfil(int idPerfil)
        {            
            try
            {
                return Ok(await _perfilRepository.DeletePerfil(new Perfil { idPerfil = idPerfil }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
