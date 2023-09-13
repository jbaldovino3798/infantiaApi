using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IMunicipio
    {
        Task<IEnumerable<Municipio>> GetAll();
        Task<Municipio> GetMunicipio(string codigoMunicipio);
        Task<bool> InsertMunicipio(Municipio municipio);
        Task<bool> UpdateMunicipio(Municipio municipio);
        Task<bool> DeleteMunicipio(Municipio municipio);
    }
}
