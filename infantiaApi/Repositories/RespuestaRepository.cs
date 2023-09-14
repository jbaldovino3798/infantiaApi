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
            var sql = @" insert into respuesta (idPregunta, respuesta, usuarioCreacion, fechaCreacion)
                        values (@IdPregunta, @CedulaCuidador, @Respuesta) ";
            var result = await db.ExecuteAsync(sql, new
            {
                respuesta.idPregunta,
                respuesta.respuesta,
                respuesta.usuarioCreacion,
                respuesta.fechaCreacion
            });
            return result > 0;
        }
        public async Task<bool> UpdateRespuesta(Respuesta respuesta)
        {
            var db = dbConnection();
            var sql = @" update respuesta 
                         set idPregunta =  @IdPregunta, 
                             respuesta = @Respuesta,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idRespuesta = @IdRespuesta";
            var result = await db.ExecuteAsync(sql, new
            {
                respuesta.idPregunta,
                respuesta.respuesta,
                respuesta.usuarioActualizacion,
                respuesta.fechaActualizacion,
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
