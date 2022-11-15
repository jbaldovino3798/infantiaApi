using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IRespTempUsu
    {
        Task<IEnumerable<RespTempUsu>> GetAll();
        Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyPregunta(int idPregunta);
        Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyTemporalidad(int idTemporalidad);
        Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyCedulaCuidador(int cedulaCuidador);
        Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyValoracion(int idValoracion);
        Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyRespuesta(int idRespuesta);
        Task<RespTempUsu> GetRespTempUsu(RespTempUsu respTempUsu);
        Task<bool> InsertRespTempUsu(RespTempUsu respTempUsu);
        Task<bool> UpdateRespTempUsu(RespTempUsu respTempUsu);
        Task<bool> DeleteRespTempUsu(RespTempUsu respTempUsu);
    }
}
