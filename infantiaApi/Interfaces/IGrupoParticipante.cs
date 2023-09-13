using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IGrupoParticipante
    {
        Task<IEnumerable<GrupoParticipante>> GetAll();
        Task<GrupoParticipante> GetGrupoParticipante(int idGrupoParticipante);
        Task<bool> InsertGrupoParticipante(GrupoParticipante grupoParticipante);
        Task<bool> UpdateGrupoParticipante(GrupoParticipante grupoParticipante);
        Task<bool> DeleteGrupoParticipante(GrupoParticipante grupoParticipante);
    }
}
