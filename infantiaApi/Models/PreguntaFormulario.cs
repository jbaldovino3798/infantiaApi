using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class PreguntaFormulario
    {
        public int idPreguntaFormulario { get; set; }
        [Required]
        public int idPregunta { get; set; }
        [Required]
        public int idFormulario { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
