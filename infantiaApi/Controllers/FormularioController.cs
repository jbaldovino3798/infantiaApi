using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormularioController : ControllerBase
    {
        private readonly IFormulario _formularioRepository;

        public FormularioController(IFormulario formularioRepository)
        {
            _formularioRepository = formularioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _formularioRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateFormulario([FromBody] Formulario formulario)
        {
            if (formulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _formularioRepository.InsertFormulario(formulario);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFormulario([FromBody] Formulario formulario)
        {
            if (formulario == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _formularioRepository.UpdateFormulario(formulario);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFormulario(int idFormulario)
        {
            await _formularioRepository.DeleteFormulario(new Formulario { idFormulario = idFormulario });
            return NoContent();
        }

    }
}
