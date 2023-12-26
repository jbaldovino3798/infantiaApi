using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace infantiaApi.Models
{
    public class GrupoParticipante
    {
        [Required]
        public int idGrupoParticipante { get; set; }
        public string descripcionGrupo { get; set; }
        public int estado { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
