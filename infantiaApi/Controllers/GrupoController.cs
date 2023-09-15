using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupo _grupoRepository;

        public GrupoController(IGrupo grupoRepository)
        {
            _grupoRepository = grupoRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _grupoRepository.GetAll());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateGrupo([FromBody] Grupo grupo)
        {
            if (grupo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _grupoRepository.InsertGrupo(grupo);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGrupo([FromBody] Grupo grupo)
        {
            if (grupo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _grupoRepository.UpdateGrupo(grupo);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGrupo(int idGrupo)
        {
            await _grupoRepository.DeleteGrupo(new Grupo { idGrupo = idGrupo });
            return NoContent();
        }

    }
}
