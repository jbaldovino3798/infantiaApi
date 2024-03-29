﻿using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Ponderacion
    {
        [Required]
        public int idPonderacion { get; set; }
        public double valor { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
