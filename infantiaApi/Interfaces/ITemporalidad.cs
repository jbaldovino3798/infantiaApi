using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ITemporalidad
    {
        Task<IEnumerable<Temporalidad>> GetAll();
        Task<Temporalidad> GetTemporalidad(int idTemporalidad);
        Task<bool> InsertTemporalidad(Temporalidad temporalidad);
        Task<bool> UpdateTemporalidad(Temporalidad temporalidad);
        Task<bool> DeleteTemporalidad(Temporalidad temporalidad);
    }
}
