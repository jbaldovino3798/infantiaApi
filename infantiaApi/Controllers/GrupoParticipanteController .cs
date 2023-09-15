using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoParticipanteController : ControllerBase
    {
        private readonly IGrupoParticipante _grupoParticipanteRepository;

        public GrupoParticipanteController(IGrupoParticipante grupoParticipanteRepository)
        {
            _grupoParticipanteRepository = grupoParticipanteRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _grupoParticipanteRepository.GetAll());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateGrupo([FromBody] GrupoParticipante grupoParticipante)
        {
            if (grupoParticipante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _grupoParticipanteRepository.InsertGrupoParticipante(grupoParticipante);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGrupoParticipante([FromBody] GrupoParticipante grupoParticipante)
        {
            if (grupoParticipante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _grupoParticipanteRepository.UpdateGrupoParticipante(grupoParticipante);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGrupoParticipante(int idGrupoParticipante)
        {
            await _grupoParticipanteRepository.DeleteGrupoParticipante(new GrupoParticipante { idGrupoParticipante = idGrupoParticipante });
            return NoContent();
        }

    }
}
