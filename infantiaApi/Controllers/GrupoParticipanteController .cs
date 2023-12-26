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
            try
            {
                return Ok(await _grupoParticipanteRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateGrupo([FromBody] GrupoParticipante grupoParticipante)
        {
            if (grupoParticipante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _grupoParticipanteRepository.InsertGrupoParticipante(grupoParticipante);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGrupoParticipante([FromBody] GrupoParticipante grupoParticipante)
        {
            if (grupoParticipante == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _grupoParticipanteRepository.UpdateGrupoParticipante(grupoParticipante));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

          [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGrupoParticipante(int idGrupoParticipante)
        {            
            try
            {
                return Ok(await _grupoParticipanteRepository.DeleteGrupoParticipante(new GrupoParticipante { idGrupoParticipante = idGrupoParticipante }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

    }
}
