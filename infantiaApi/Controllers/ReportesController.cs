using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReportes _reportesRepository;

        public ReportesController(IReportes reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> getReportes()
        {
            try
            {
                return Ok(await _reportesRepository.GetReportes());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> getReporte(int idReporte, string? parametrosJson)
        {
            try
            {
                if (parametrosJson == null)
                {
                    // Si no se proporciona el JSON de parámetros, pasamos una cadena vacía
                    parametrosJson = "{}";
                }
                return Ok(await _reportesRepository.GetReporte(idReporte, parametrosJson));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }
    }

 }

