using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace infantiaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadorController : ControllerBase
    {
        private readonly ICuidador _cuidadorRepository;

        public CuidadorController(ICuidador cuidadorRepository)
        {
            _cuidadorRepository = cuidadorRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _cuidadorRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetCuidador(int cedulaCuidador)
        {
            try
            {
                return Ok(await _cuidadorRepository.GetCuidador(cedulaCuidador));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]/{idPerfil}")]
        public async Task<IActionResult> GetAllbyPerfil(int idPerfil)
        {
            try
            {
                return Ok(await _cuidadorRepository.GetAllbyPerfil(idPerfil));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCuidador([FromBody] Cuidador cuidador)
        {
            if (cuidador == null)            
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _cuidadorRepository.InsertCuidador(cuidador);
                return Created("created", created);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCuidador([FromBody] Cuidador cuidador)
        {
            if (cuidador == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _cuidadorRepository.UpdateCuidador(cuidador));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCuidador(int cedulaCuidador)
        {
            try
            {                
                return Ok(await _cuidadorRepository.DeleteCuidador(new Cuidador { cedulaCuidador = cedulaCuidador }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }
}
