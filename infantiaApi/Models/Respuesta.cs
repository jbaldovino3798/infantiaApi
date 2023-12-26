using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Respuesta
    {
        [Required]
        public int idRespuesta { get; set; }
        [Required]
        public string respuesta { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
