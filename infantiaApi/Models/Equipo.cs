using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Equipo
    {

        [Required]
        public int cedulaMiembro { get; set; }
        public string nombreMiembro { get; set; }
        public string ocupacion { get; set; }
        public int rol { get; set; }
        public int estado { get; set; }
        [Required]
        public string password { get; set; }
        public string token { get; set; }
        public string fechaExpiracionToken { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }


}
