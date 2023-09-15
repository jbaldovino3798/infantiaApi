﻿using infantiaApi.Interfaces;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _smsRepository.GetAll());
        }

        [HttpGet("[action]/{idGrupo}")]
        public async Task<IActionResult> GetAllbyGrupo(int idGrupo)
        {
            return Ok(await _smsRepository.GetAllbyGrupo(idGrupo));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _smsRepository.InsertSms(sms);
            return Created("created", created);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateSms([FromBody] Sms sms)
        {
            if (sms == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _smsRepository.UpdateSms(sms);
            return NoContent();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteSms(int idSms)
        {
            await _smsRepository.DeleteSms(new Sms { idSms = idSms });
            return NoContent();
        }

    }
}
