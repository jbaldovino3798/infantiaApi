using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RespTempUsuController : ControllerBase
    {
        private readonly IRespTempUsu _respTempUsuRepository;

        public RespTempUsuController(IRespTempUsu respTempUsuRepository)
        {
            _respTempUsuRepository = respTempUsuRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _respTempUsuRepository.GetAll());
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetRespTempUsu([FromBody] RespTempUsu respTempUsu)
        {
            return Ok(await _respTempUsuRepository.GetRespTempUsu(respTempUsu));
        }

        [Authorize]
        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllRespTempUsubyCedulaCuidador(int cedulaCuidador)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyCedulaCuidador(cedulaCuidador));
        }

        [Authorize]
        [HttpGet("[action]/{idTemporalidad}")]
        public async Task<IActionResult> GetAllRespTempUsubyTemporalidad(int idTemporalidad)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyTemporalidad(idTemporalidad));
        }

        [Authorize]
        [HttpGet("[action]/{idPregunta}")]
        public async Task<IActionResult> GetAllRespTempUsubyPregunta(int idPregunta)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyPregunta(idPregunta));
        }

        [Authorize]
        [HttpGet("[action]/{idValoracion}")]
        public async Task<IActionResult> GetAllRespTempUsubyValoracion(int idValoracion)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyValoracion(idValoracion));
        }

        [Authorize]
        [HttpGet("[action]/{idRepuesta}")]
        public async Task<IActionResult> GetAllRespTempUsubyRespuesta(int idRepuesta)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyRespuesta(idRepuesta));
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCuidador([FromBody] RespTempUsu respTempUsu)
        {
            if (respTempUsu == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _respTempUsuRepository.InsertRespTempUsu(respTempUsu);
            return Created("created", created);
        }

        /*[HttpPut("[action]")]
        public async Task<IActionResult> UpdateCuidador([FromBody] RespTempUsu respTempUsu)
        {
            if (respTempUsu == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _respTempUsuRepository.UpdateRespTempUsu(respTempUsu);
            return NoContent();
        }*/

        [Authorize]
        [HttpDelete("[action]/{cedulaCuidador}/{idFormulario}")]
        public async Task<IActionResult> DeleteCuidador([FromBody] RespTempUsu respTempUsu)
        {
            if (respTempUsu == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _respTempUsuRepository.DeleteRespTempUsu(respTempUsu);
            return NoContent();
        }
    }
}
