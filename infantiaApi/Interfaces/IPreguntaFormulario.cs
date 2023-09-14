using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IPreguntaFormulario
    {
        Task<IEnumerable<PreguntaFormulario>> GetAll();
        //Task<PreguntaFormulario> GetPreguntaFormulario(int idPregunta);
        Task<bool> InsertPreguntaFormulario(PreguntaFormulario preguntaFormulario);
        Task<bool> UpdatePreguntaFormulario(PreguntaFormulario preguntaFormulario);
        Task<bool> DeletePreguntaFormulario(PreguntaFormulario preguntaFormulario);
    }
}
