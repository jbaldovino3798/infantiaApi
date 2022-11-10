using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IEquipo
    {
        Task<IEnumerable<Equipo>> GetAll();
        Task<Equipo> GetEquipo(int cedulaMiembro);
        Task<bool> InsertEquipo(Equipo equipo);
        Task<bool> UpdateEquipo(Equipo equipo);
        Task<bool> DeleteEquipo(Equipo equipo);
    }
}
