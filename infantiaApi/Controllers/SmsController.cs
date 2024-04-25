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
    public class SmsController : ControllerBase
    {
        private readonly ISms _smsRepository;

        public SmsController(ISms smsRepository)
        {
            _smsRepository = smsRepository;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _smsRepository.GetAll());
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpGet("[action]/{idGrupo}")]
        public async Task<IActionResult> GetAllbyGrupo(int idGrupo)
        {
            try
            {
                return Ok(await _smsRepository.GetAllbyGrupo(idGrupo));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _smsRepository.InsertSms(sms);
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
        public async Task<IActionResult> UpdateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _smsRepository.UpdateSms(sms));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSms(int idSms)
        {
            try
            {
                return Ok(await _smsRepository.DeleteSms(new Sms { idSms = idSms }));
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log them)
                return StatusCode(500, "An error occurred while processing the request. " + ex);
            }
        }

    }
}
