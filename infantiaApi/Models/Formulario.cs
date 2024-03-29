﻿using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Formulario
    {
        [Required]
        public int idFormulario { get; set; }
        public string descripcion { get; set; }
        public int nroPreguntas { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
