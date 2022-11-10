using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ICuidadorFormulario
    {
        Task<IEnumerable<CuidadorFormulario>> GetAll();
        Task<IEnumerable<CuidadorFormulario>> GetAllbyFormulario(int idFormulario);
        Task<CuidadorFormulario> GetCuidadorFormulario(int cedulaCuidador);
        Task<bool> InsertCuidadorFormulario(CuidadorFormulario cuidadorFormulario);
        Task<bool> UpdateCuidadorFormulario(CuidadorFormulario cuidadorFormulario);
        Task<bool> DeleteCuidadorFormulario(CuidadorFormulario cuidadorFormulario);
    }
}
