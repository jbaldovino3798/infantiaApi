using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Xml.Linq;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfilRepository;

        public PerfilController(IPerfil perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        [HttpGet("[action]")]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> GetAll()
        {
            String data = JsonSerializer.Serialize(await _perfilRepository.GetAll());
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePerfil([FromBody] Perfil perfil)
        {
            if (perfil == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _perfilRepository.InsertPerfil(perfil);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePerfil([FromBody] Perfil perfil)
        {
            if (perfil == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _perfilRepository.UpdatePerfil(perfil);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePerfil(int idPerfil)
        {
            await _perfilRepository.DeletePerfil(new Perfil { idPerfil = idPerfil });
            return NoContent();
        }
    }
}
