using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infantiaApi.Models
{
    public class Cuidador
    {
        public int cedulaCuidador { get; set; }
        public string nombreCuidador { get; set; }
        public int edad { get; set; }
        public string direccion { get; set; }
        public string barrio { get; set; }
        public int estrato { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string estadoCivil { get; set; }
        public bool parejaDiferente { get; set; }
        public string grupoEtnico { get; set; }
        public string nivelEducativo { get; set; }
        public string ocupacion { get; set; }
        public string nombreNiño { get; set; }
        public string parentesco { get; set; }
        public int idPerfil { get; set; }
    }
}
