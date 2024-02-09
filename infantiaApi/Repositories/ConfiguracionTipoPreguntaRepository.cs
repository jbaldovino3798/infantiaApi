using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class ConfiguracionTipoPreguntaRepository : IConfiguracionTipoPregunta
    {
        private readonly MySQLConfiguration _connectionString;
        public ConfiguracionTipoPreguntaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteConfiguracionTipoPregunta(int idConfiguracion)
        {
            var db = dbConnection();
            var sql = @" delete from configuracion_tipoPregunta 
                         where idConfiguracion = @IdConfiguracion ";
            var result = await db.ExecuteAsync(sql, new { IdConfiguracion = idConfiguracion });
            return result > 0;
        }
        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select *,
                            (select descripcion from tipopregunta where idTipoPregunta = ctp.idTipoPregunta) as tipoPregunta
                            from configuracion_tipoPregunta ctp ";
            return await db.QueryAsync<dynamic>(sql, new { });
        }
        public async Task<IEnumerable<ConfiguracionTipoPregunta>> GetAllbyTipoPregunta(int idTipoPregunta)
        {
            var db = dbConnection();
            var sql = @" select * from configuracion_tipoPregunta 
                         where idTipoPregunta = @IdTipoPregunta ";
            return await db.QueryAsync<ConfiguracionTipoPregunta>(sql, new { IdTipoPregunta = idTipoPregunta });
        }
        public async Task<bool> InsertConfiguracionTipoPregunta(ConfiguracionTipoPregunta configuracionTipoPregunta)
        {
            var db = dbConnection();
            var sql = @" insert into configuracion_tipoPregunta (idTipoPregunta,descripcion, orden, usuarioCreacion, fechaCreacion)
                        values (@IdTipoPregunta, @Descripcion, @Orden, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            configuracionTipoPregunta.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            configuracionTipoPregunta.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                configuracionTipoPregunta.idTipoPregunta,
                configuracionTipoPregunta.descripcion,
                configuracionTipoPregunta.orden,
                configuracionTipoPregunta.usuarioCreacion,
                configuracionTipoPregunta.fechaCreacion
            });
            return result > 0;
        }
        public async Task<bool> UpdateConfiguracionTipoPregunta(ConfiguracionTipoPregunta configuracionTipoPregunta)
        {
            var db = dbConnection();
            var sql = @" update configuracion_tipoPregunta 
                         set idTipoPregunta = @IdTipoPregunta
                             descripcion = @Descripcion,
                             orden = @Orden,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idConfiguracion = @IdConfiguracion";

            DateTime fechaActualizacion = DateTime.Now;
            configuracionTipoPregunta.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            configuracionTipoPregunta.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                configuracionTipoPregunta.idTipoPregunta,
                configuracionTipoPregunta.descripcion,
                configuracionTipoPregunta.orden,
                configuracionTipoPregunta.usuarioActualizacion,
                configuracionTipoPregunta.fechaActualizacion,
                configuracionTipoPregunta.idConfiguracion
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
