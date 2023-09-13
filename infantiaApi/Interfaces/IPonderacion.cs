using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IPonderacion
    {
        Task<IEnumerable<Ponderacion>> GetAll();
        Task<Ponderacion> GetPonderacion(int idPonderacion);
        Task<bool> InsertPonderacion(Ponderacion ponderacion);
        Task<bool> UpdatePonderacion(Ponderacion ponderacion);
        Task<bool> DeletePonderacion(Ponderacion ponderacion);
    }
}
