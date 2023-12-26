using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
            try
            {
                return Ok(await _grupoRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateGrupo([FromBody] Grupo grupo)
        {
            if (grupo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _grupoRepository.InsertGrupo(grupo);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGrupo([FromBody] Grupo grupo)
        {
            if (grupo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            try
            {
                return Ok(await _grupoRepository.UpdateGrupo(grupo));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGrupo(int idGrupo)
        {
            try
            {
                return Ok(await _grupoRepository.DeleteGrupo(new Grupo { idGrupo = idGrupo }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

    }
}
