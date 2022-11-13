using infantiaApi.Interfaces;
using infantiaApi.Models;
using infantiaApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ISms _smsRepository;

        public SmsController(ISms smsRepository)
        {
            _smsRepository = smsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _smsRepository.GetAll());
        }

        [HttpGet("[action]/{idPerfil}")]
        public async Task<IActionResult> GetAllbyPerfil(int idPerfil)
        {
            return Ok(await _smsRepository.GetAllbyPerfil(idPerfil));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _smsRepository.InsertSms(sms);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _smsRepository.UpdateSms(sms);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSms(int idSms)
        {
            await _smsRepository.DeleteSms(new Sms { idSms = idSms });
            return NoContent();
        }

    }
}
