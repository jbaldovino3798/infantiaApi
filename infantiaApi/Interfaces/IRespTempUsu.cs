using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IRespTempUsu
    {
        Task<IEnumerable<RespTempUsu>> GetAll();
        Task<RespTempUsu> GetRespTempUsubyPregunta(int idPregunta);
        Task<RespTempUsu> GetRespTempUsubyTemporalidad(int idTemporalidad);
        Task<RespTempUsu> GetRespTempUsubyCedulaCuidador(int cedulaCuidador);
        Task<RespTempUsu> GetRespTempUsubyValoraciona(int idValoracion);
        Task<RespTempUsu> GetRespTempUsubyRespuesta(int idRespuesta);
        Task<bool> InsertRespTempUsu(RespTempUsu respTempUsu);
        Task<bool> UpdateRespTempUsu(RespTempUsu respTempUsu);
        Task<bool> DeleteRespTempUsu(RespTempUsu respTempUsu);
    }
}
