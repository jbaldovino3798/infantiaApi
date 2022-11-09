using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ICuidadorRepository
    {
        Task<IEnumerable<Cuidador>> GetAll();
        Task<Cuidador> GetCuidador(int cedulaCuidador);
        Task<bool> InsertCuidador(Cuidador cuidador);
        Task<bool> UpdateCuidador(Cuidador cuidador);
        Task<bool> DeleteCuidador(Cuidador cuidador);
    }
}
