using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infantiaApi.Models
{
    public class Perfil
    {
        [Required]
        public int idPerfil { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        [Required]
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
