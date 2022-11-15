using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IRespuesta
    {
        Task<IEnumerable<Respuesta>> GetAll();
        Task<IEnumerable<Respuesta>> GetAllbyPregunta(int idPregunta);
        Task<IEnumerable<Respuesta>> GetAllbyCuidador(int cedulaCuidador);
        Task<Respuesta> GetRespuesta(int idRespuesta);
        Task<bool> InsertRespuesta(Respuesta respuesta);
        Task<bool> UpdateRespuesta(Respuesta respuesta);
        Task<bool> DeleteRespuesta(Respuesta respuesta);
    }
}
