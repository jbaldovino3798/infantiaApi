using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IReportes
    {
        Task<IEnumerable<dynamic>> GetReportes();
        Task<string> GetReporte(int idReporte, string parametrosJson);
    }
}
