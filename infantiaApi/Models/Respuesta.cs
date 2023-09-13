﻿using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Respuesta
    {
        [Required]
        public int idRespuesta { get; set; }
        [Required]
        public int idPregunta { get; set; }
        public string respuesta { get; set; }
        public int estado { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
