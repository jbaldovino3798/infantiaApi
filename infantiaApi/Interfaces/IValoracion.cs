using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IValoracion
    {
        Task<IEnumerable<Valoracion>> GetAll();
        Task<Valoracion> GetValoracion(int idValoracion);
        Task<bool> InsertValoracion(Valoracion valoracion);
        Task<bool> UpdateValoracion(Valoracion valoracion);
        Task<bool> DeleteValoracion(Valoracion valoracion);
    }
}
