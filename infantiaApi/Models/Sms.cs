using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Sms
    {
        [Required]
        public int idSms { get; set; }
        [Required]
        public int idGrupo { get; set; }
        public string mensaje { get; set; }
        public int semana { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
