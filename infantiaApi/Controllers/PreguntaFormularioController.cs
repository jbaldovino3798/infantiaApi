using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntaFormularioController : ControllerBase
    {
        private readonly IPreguntaFormulario _preguntaFormularioRepository;

        public PreguntaFormularioController(IPreguntaFormulario preguntaFormularioRepository)
        {
            _preguntaFormularioRepository = preguntaFormularioRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _preguntaFormularioRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpGet("[action]/{idFormulario}")]
        public async Task<IActionResult> GetPreguntasbyFormulario(int idFormulario)
        {
            try
            {
                return Ok(await _preguntaFormularioRepository.GetPreguntasbyFormulario(idFormulario));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        /*[HttpGet("[action]/{cedulaCuidador}/{idFormulario}")]
        public async Task<IActionResult> GetCuidador(int cedulaCuidador, int idFormulario)
        {
            return Ok(await _preguntaFormularioRepository.GetCuidadorFormulario(cedulaCuidador, idFormulario));
        }

        [HttpGet("[action]/{idFormulario}")]
        public async Task<IActionResult> GetAllbyFormulario(int idFormulario)
        {
            return Ok(await _cuidadorFormularioRepository.GetAllbyFormulario(idFormulario));
        }

        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetAllbyCuidador(int cedulaCuidador)
        {
            return Ok(await _cuidadorFormularioRepository.GetAllbyCuidador(cedulaCuidador));
        }
        */
        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePreguntaFormulario([FromBody] PreguntaFormulario preguntaFormulario)
        {
            if (preguntaFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _preguntaFormularioRepository.InsertPreguntaFormulario(preguntaFormulario);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePreguntaFormulario([FromBody] PreguntaFormulario preguntaFormulario)
        {
            if (preguntaFormulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _preguntaFormularioRepository.UpdatePreguntaFormulario(preguntaFormulario));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [HttpDelete("[action]/{idPregunta}/{idFormulario}")]
        public async Task<IActionResult> DeletePreguntaFormulario(int idPregunta, int idFormulario)
        {
            try
            {
                return Ok(await _preguntaFormularioRepository.DeletePreguntaFormulario(new PreguntaFormulario
                {
                    idPregunta = idPregunta,
                    idFormulario = idFormulario
                }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
