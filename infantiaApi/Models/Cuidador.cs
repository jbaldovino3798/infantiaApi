using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace infantiaApi.Models
{
    public class Cuidador
    {
        [Required]
        public int cedulaCuidador { get; set; }
        [Required]
        public string nombreCuidador { get; set; }
        [Required]
        public int edad { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        [Required]
        public int estrato { get; set; }
        [Required]
        public string telefono { get; set; }
        public string email { get; set; }
        public string estadoCivil { get; set; }
        public int parejaDiferente { get; set; }
        public string grupoEtnico { get; set; }
        public string nivelEducativo { get; set; }
        public string ocupacion { get; set; }
        [Required]
        public string nombreNiño { get; set; }
        [Required]
        public int edadMenor { get; set; }
        [Required]
        public string parentesco { get; set; }
        [Required]
        public string fechaNacimientoMenor { get; set; }
        [Required]
        public string codigoMunicipio { get; set; }
        [Required]
        public int idGrupo { get; set; }
        [Required]
        public int idGrupoParticipante { get; set; }
        [Required]
        public int idPerfil { get; set; }
        public string usuarioCreacion { get; set; }
        public string fechaCreacion { get; set; }
        public string usuarioActualizacion { get; set; }
        public string fechaActualizacion { get; set; }
    }
}
