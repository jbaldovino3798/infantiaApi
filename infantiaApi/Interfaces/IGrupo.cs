using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IGrupo
    {
        Task<IEnumerable<Grupo>> GetAll();
        Task<Grupo> GetGrupo(int idGrupo);
        Task<bool> InsertGrupo(Grupo grupo);
        Task<bool> UpdateGrupo(Grupo grupo);
        Task<bool> DeleteGrupo(Grupo grupo);
    }
}
