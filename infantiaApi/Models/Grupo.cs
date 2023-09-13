using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Grupo
    {
        [Required]
        public int idGrupo { get; set; }
        public string descripcionGrupo { get; set; }
        public int rangoMinimo { get; set; }
        public int rangoMaximo { get; set; }
        public int estado { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
