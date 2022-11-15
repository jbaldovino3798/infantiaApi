using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class RespTempUsuRepository : IRespTempUsu
    {
        private readonly MySQLConfiguration _connectionString;
        public RespTempUsuRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteRespTempUsu(RespTempUsu respTempUsu)
        {
            var db = dbConnection();
            var sql = @" delete from resptempusu 
                         where idTemporalidad = @IdTemporalidad 
                         and idPregunta = @IdPregunta
                         and idRespuseta = @IdRespuesta
                         and cedulaCuidador = @CedulaCuidador
                         and idValoracion = @IdValoracion";
            var result = await db.ExecuteAsync(sql, new
            {
                IdTemporalidad = respTempUsu.idTemporalidad,
                IdPregunta = respTempUsu.idPregunta,
                IdRespuesta = respTempUsu.idRespuesta,
                CedulaCuidador = respTempUsu.cedulaCuidador,
                IdValoracion = respTempUsu.idValoracion
            });
            return result > 0;
        }
        public async Task<IEnumerable<RespTempUsu>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from resptempusu ";
            return await db.QueryAsync<RespTempUsu>(sql, new { });
        }
        public async Task<RespTempUsu> GetRespTempUsu(RespTempUsu respTempUsu)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from resptempusu
                        where idTemporalidad = @IdTemporalidad 
                        and idPregunta = @IdPregunta
                        and idRespuseta = @IdRespuesta
                        and cedulaCuidador = @CedulaCuidador
                        and idValoracion = @IdValoracion ";
            return await db.QueryFirstOrDefaultAsync<RespTempUsu>(sql, new
            {
                IdTemporalidad = respTempUsu.idTemporalidad,
                IdPregunta = respTempUsu.idPregunta,
                IdRespuesta = respTempUsu.idRespuesta,
                CedulaCuidador = respTempUsu.cedulaCuidador,
                IdValoracion = respTempUsu.idValoracion
            });
        }
        public async Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyCedulaCuidador(int cedulaCuidador)
        {
            var db = dbConnection();
            var sql = @" Select * 
                        from resptempusu 
                        where cedulaCuidador = @CedulaCuidador ";
            return await db.QueryAsync<RespTempUsu>(sql, new { CedulaCuidador = cedulaCuidador });
        }
        public async Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyPregunta(int idPregunta)
        {
            var db = dbConnection();
            var sql = @" Select * 
                        from resptempusu 
                        where idPregunta = @IdPregunta ";
            return await db.QueryAsync<RespTempUsu>(sql, new { IdPregunta = idPregunta });
        }
        public async Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyRespuesta(int idRespuesta)
        {
            var db = dbConnection();
            var sql = @" Select * 
                        from resptempusu 
                        where idRespuesta = @IdRespuesta ";
            return await db.QueryAsync<RespTempUsu>(sql, new { IdRespuesta = idRespuesta });
        }
        public async Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyTemporalidad(int idTemporalidad)
        {
            var db = dbConnection();
            var sql = @" Select * 
                        from resptempusu 
                        where idTemporalidad = @IdTemporalidad ";
            return await db.QueryAsync<RespTempUsu>(sql, new { IdTemporalidad = idTemporalidad });
        }
        public async Task<IEnumerable<RespTempUsu>> GetAllRespTempUsubyValoracion(int idValoracion)
        {
            var db = dbConnection();
            var sql = @" Select * 
                        from resptempusu 
                        where idValoracion = @IdValoracion ";
            return await db.QueryAsync<RespTempUsu>(sql, new { IdValoracion = idValoracion });
        }
        public async Task<bool> InsertRespTempUsu(RespTempUsu respTempUsu)
        {
            var db = dbConnection();
            var sql = @" insert into resptempusu (idTemporalidad, idPregunta, idRespuesta, cedulaCuidador, idValoracion)
                        values (@IdTemporalidad, @IdPregunta, @IdRespuesta, @CedulaCuidador, @IdValoracion) ";
            var result = await db.ExecuteAsync(sql, new
            {
                IdTemporalidad = respTempUsu.idTemporalidad,
                IdPregunta = respTempUsu.idPregunta,
                IdRespuesta = respTempUsu.idRespuesta,
                CedulaCuidador = respTempUsu.cedulaCuidador,
                IdValoracion = respTempUsu.idValoracion
            });
            return result > 0;
        }
        public async Task<bool> UpdateRespTempUsu(RespTempUsu respTempUsu)
        {
            var db = dbConnection();
            var sql = @" update resptempusu 
                         set idTemporalidad =  @IdTemporalidad,
                             idPregunta = @IdPregunta,
                             idRespuesta = @IdRespuesta,
                             cedulaCuidador = @CedulaCuidador,
                             idValoracion = @IdValoracion";
            var result = await db.ExecuteAsync(sql, new
            {
                IdTemporalidad = respTempUsu.idTemporalidad,
                IdPregunta = respTempUsu.idPregunta,
                IdRespuesta = respTempUsu.idRespuesta,
                CedulaCuidador = respTempUsu.cedulaCuidador,
                IdValoracion = respTempUsu.idValoracion
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
