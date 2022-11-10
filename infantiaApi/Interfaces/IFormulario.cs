using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IFormulario
    {
        Task<IEnumerable<Formulario>> GetAll();
        Task<Formulario> GetFormulario(int idFormulario);
        Task<bool> InsertFormulario(Formulario formulario);
        Task<bool> UpdateFormulario(Formulario formulario);
        Task<bool> DeleteFormulario(Formulario formulario);
    }
}
