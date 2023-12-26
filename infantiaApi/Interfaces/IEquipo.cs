using infantiaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Interfaces
{
    public interface IEquipo
    {
        Task<IEnumerable<Equipo>> GetAll();
        Task<Equipo> GetEquipo(int cedulaMiembro);
        Task<IEnumerable<dynamic>> GetOpcionesSistema(int cedulaMiembro);
        Task<bool> InsertEquipo(Equipo equipo);
        Task<bool> UpdateEquipo(Equipo equipo);
        Task<bool> DeleteEquipo(int cedulaMiembro);
        Task<bool> GenerateAndStoreToken(int cedulaCuidador);
        Task<bool> AuthenticateAsync(int cedulaMiembro, string password);
    }
}
