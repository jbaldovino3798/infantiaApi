using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IConfiguracionTipoPregunta
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<IEnumerable<ConfiguracionTipoPregunta>> GetAllbyTipoPregunta(int idTipoPregunta);
        Task<bool> InsertConfiguracionTipoPregunta(ConfiguracionTipoPregunta configuracionTipoPregunta);
        Task<bool> UpdateConfiguracionTipoPregunta(ConfiguracionTipoPregunta configuracionTipoPregunta);
        Task<bool> DeleteConfiguracionTipoPregunta(int idConfiguracion);
    }
}
