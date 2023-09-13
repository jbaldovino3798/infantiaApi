using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Formulario
    {
        public int idFormulario { get; set; }
        public string descripcion { get; set; }
        public int nroPreguntas { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }

    }
}
