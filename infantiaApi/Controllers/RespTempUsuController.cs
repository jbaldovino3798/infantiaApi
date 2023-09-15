using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespTempUsuController : ControllerBase
    {
        private readonly IRespTempUsu _respTempUsuRepository;

        public RespTempUsuController(IRespTempUsu respTempUsuRepository)
        {
            _respTempUsuRepository = respTempUsuRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _respTempUsuRepository.GetAll());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetRespTempUsu([FromBody] RespTempUsu respTempUsu)
        {
            return Ok(await _respTempUsuRepository.GetRespTempUsu(respTempUsu));
        }

        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllRespTempUsubyCedulaCuidador(int cedulaCuidador)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyCedulaCuidador(cedulaCuidador));
        }

        [HttpGet("[action]/{idTemporalidad}")]
        public async Task<IActionResult> GetAllRespTempUsubyTemporalidad(int idTemporalidad)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyTemporalidad(idTemporalidad));
        }

        [HttpGet("[action]/{idPregunta}")]
        public async Task<IActionResult> GetAllRespTempUsubyPregunta(int idPregunta)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyPregunta(idPregunta));
        }

        [HttpGet("[action]/{idValoracion}")]
        public async Task<IActionResult> GetAllRespTempUsubyValoracion(int idValoracion)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyValoracion(idValoracion));
        }

        [HttpGet("[action]/{idRepuesta}")]
        public async Task<IActionResult> GetAllRespTempUsubyRespuesta(int idRepuesta)
        {
            return Ok(await _respTempUsuRepository.GetAllRespTempUsubyRespuesta(idRepuesta));
        }
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
