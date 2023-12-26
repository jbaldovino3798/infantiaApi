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
            var sql = @" insert into respuesta (respuesta, usuarioCreacion, fechaCreacion)
                        values (@IdPregunta, @Respuesta, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            respuesta.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            respuesta.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
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
                         set respuesta = @Respuesta,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idRespuesta = @IdRespuesta";

            DateTime fechaActualizacion = DateTime.Now;
            respuesta.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            respuesta.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
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
