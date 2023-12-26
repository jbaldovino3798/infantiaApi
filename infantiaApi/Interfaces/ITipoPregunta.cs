using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ITipoPregunta
    {
        Task<IEnumerable<TipoPregunta>> GetAll();
        Task<bool> InsertTipoPregunta(TipoPregunta tipoPregunta);
        Task<bool> UpdateTipoPregunta(TipoPregunta tipoPregunta);
        Task<bool> DeleteTipoPregunta(int idTipoPregunta);
    }
}
