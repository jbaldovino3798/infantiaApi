using infantiaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace infantiaApi.Interfaces
{
    public interface IEquipo
    {
        Task<IEnumerable<Equipo>> GetAll();
        Task<Equipo> GetEquipo(int cedulaMiembro);
        Task<ApiResponse> GetOpcionesSistema(int cedulaMiembro);
        Task<dynamic> GetRoles();
        Task<bool> InsertEquipo(Equipo equipo);
        Task<bool> UpdateEquipo(Equipo equipo);
        Task<bool> DeleteEquipo(int cedulaMiembro);
        Task<string> GenerateAndStoreToken(int cedulaCuidador);
        Task<bool> AuthenticateAsync(int cedulaMiembro, string password);
    }
}
