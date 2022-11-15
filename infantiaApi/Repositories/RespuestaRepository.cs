using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class RespuestaRepository : IRespuesta
    {
        private readonly MySQLConfiguration _connectionString;
        public RespuestaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteRespuesta(Respuesta respuesta)
        {
            var db = dbConnection();
            var sql = @" delete from respuesta 
                         where idRespuesta = @IdRespuesta ";
            var result = await db.ExecuteAsync(sql, new { IdRespuesta = respuesta.idRespuesta });
            return result > 0;
        }
        public async Task<IEnumerable<Respuesta>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from respuesta ";
            return await db.QueryAsync<Respuesta>(sql, new { });
        }
        public async Task<IEnumerable<Respuesta>> GetAllbyCuidador(int cedulaCuidador)
        {
            var db = dbConnection();
            var sql = @" select * from respuesta 
                         where cedulaCuidador = @CedulaCuidador ";
            return await db.QueryAsync<Respuesta>(sql, new { CedulaCuidador = cedulaCuidador });
        }
        public async Task<IEnumerable<Respuesta>> GetAllbyPregunta(int idPregunta)
        {
            var db = dbConnection();
            var sql = @" select * from respuesta 
                         where idPregunta = @IdPregunta ";
            return await db.QueryAsync<Respuesta>(sql, new { IdPregunta = idPregunta });
        }
        public async Task<Respuesta> GetRespuesta(int idRespuesta)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from respuesta
                        where idRespuesta = @IdRespuesta ";
            return await db.QueryFirstOrDefaultAsync<Respuesta>(sql, new { IdRespuesta = idRespuesta });
        }
        public async Task<bool> InsertRespuesta(Respuesta respuesta)
        {
            var db = dbConnection();
            var sql = @" insert into respuesta (idPregunta, cedulaCuidador, respuesta)
                        values (@IdPregunta, @CedulaCuidador, @Respuesta) ";
            var result = await db.ExecuteAsync(sql, new
            {
                respuesta.idPregunta,
                respuesta.cedulaCuidador,
                respuesta.respuesta
            });
            return result > 0;
        }
        public async Task<bool> UpdateRespuesta(Respuesta respuesta)
        {
            var db = dbConnection();
            var sql = @" update respuesta 
                         set idPregunta =  @IdPregunta,
                             cedulaCuidador = @CedulaCuidador,
                             respuesta = @Respuesta
                        where idRespuesta = @IdRespuesta";
            var result = await db.ExecuteAsync(sql, new
            {
                respuesta.idPregunta,
                respuesta.cedulaCuidador,
                respuesta.respuesta,
                respuesta.idRespuesta
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
