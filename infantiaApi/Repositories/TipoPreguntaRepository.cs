using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class TipoPreguntaRepository : ITipoPregunta
    {
        private readonly MySQLConfiguration _connectionString;
        public TipoPreguntaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteTipoPregunta(int idTipoPregunta)
        {
            var db = dbConnection();
            var sql = @" delete from tipoPregunta 
                         where idTipoPregunta = @IdTipoPregunta ";
            var result = await db.ExecuteAsync(sql, new { IdTipoPregunta = idTipoPregunta });
            return result > 0;
        }
        public async Task<IEnumerable<TipoPregunta>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from tipoPregunta ";
            return await db.QueryAsync<TipoPregunta>(sql, new { });
        }
        public async Task<bool> InsertTipoPregunta(TipoPregunta tipoPregunta)
        {
            var db = dbConnection();
            var sql = @" insert into tipoPregunta (descripcion, usuarioCreacion, fechaCreacion)
                        values (@Descripcion, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            tipoPregunta.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            tipoPregunta.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                tipoPregunta.descripcion,
                tipoPregunta.usuarioCreacion,
                tipoPregunta.fechaCreacion
            });
            return result > 0;
        }
        public async Task<bool> UpdateTipoPregunta(TipoPregunta tipoPregunta)
        {
            var db = dbConnection();
            var sql = @" update tipoPregunta 
                         set descripcion = @Descripcion,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idTipoPregunta = @IdTipoPregunta";

            DateTime fechaActualizacion = DateTime.Now;
            tipoPregunta.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            tipoPregunta.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                tipoPregunta.descripcion,
                tipoPregunta.usuarioActualizacion,
                tipoPregunta.fechaActualizacion,
                tipoPregunta.idTipoPregunta
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
