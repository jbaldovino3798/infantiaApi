using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class RespTempUsu
    {
        [Required]
        public int cedulaCuidador { get; set; }
        [Required]
        public int idTemporalidad { get; set; }
        [Required]
        public int idValoracion { get; set; }
        [Required]
        public int idPregunta { get; set; }
        [Required]
        public int idRespuesta { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
