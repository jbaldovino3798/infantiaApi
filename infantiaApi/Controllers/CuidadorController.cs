﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Interfaces;
using infantiaApi.Models;

namespace infantiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuidadorController : ControllerBase
    {
        private readonly ICuidador _cuidadorRepository;

        public CuidadorController(ICuidador cuidadorRepository)
        {
            _cuidadorRepository = cuidadorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cuidadorRepository.GetAll());
        }
        
        [HttpGet("[action]/{cedulaCuidador}")]
        public async Task<IActionResult> GetCuidador(int cedulaCuidador)
        {
            return Ok(await _cuidadorRepository.GetCuidador(cedulaCuidador));
        }

        [HttpGet("[action]/{idPerfil}")]
        public async Task<IActionResult> GetAllbyPerfil(int idPerfil)
        {
            return Ok(await _cuidadorRepository.GetAllbyPerfil(idPerfil));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCuidador([FromBody] Cuidador cuidador)
        {
            if (cuidador == null)            
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _cuidadorRepository.InsertCuidador(cuidador);
            return Created("created", created);            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCuidador([FromBody] Cuidador cuidador)
        {
            if (cuidador == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _cuidadorRepository.UpdateCuidador(cuidador);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCuidador(int cedulaCuidador)
        {
            await _cuidadorRepository.DeleteCuidador(new Cuidador { cedulaCuidador = cedulaCuidador });
            return NoContent();
        }
    }
}
