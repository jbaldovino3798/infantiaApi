using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Pregunta
    {
        [Required]
        public int idPregunta { get; set; }
        [Required]
        public int idTipoPregunta { get; set; }
        public int idPonderacion { get; set; }
        [Required]
        public string pregunta { get; set; }
        public string tipoDato { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
