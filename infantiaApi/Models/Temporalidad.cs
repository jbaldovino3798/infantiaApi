using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Temporalidad
    {
        [Required]
        public int idTemporalidad { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
