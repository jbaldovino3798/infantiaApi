using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipo _equipoRepository;

        public EquipoController(IEquipo equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _equipoRepository.GetAll());
        }

        [HttpGet("[action]/{cedulaMiembro}")]
        public async Task<IActionResult> GetEquipo(int cedulaMiembro)
        {
            return Ok(await _equipoRepository.GetEquipo(cedulaMiembro));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertEquipo([FromBody] Equipo equipo)
        {
            if (equipo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _equipoRepository.InsertEquipo(equipo);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEquipo([FromBody] Equipo equipo)
        {
            if (equipo == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _equipoRepository.UpdateEquipo(equipo);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteEquipo(int cedulaMiembro)
        {
            await _equipoRepository.DeleteEquipo(new Equipo { cedulaMiembro = cedulaMiembro });
            return NoContent();
        }
    }
}
