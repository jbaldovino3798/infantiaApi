using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class PonderacionRepository : IPonderacion
    {
        private readonly MySQLConfiguration _connectionString;
        public PonderacionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeletePonderacion(int idPonderacion)
        {
            var db = dbConnection();
            var sql = @"delete from ponderacion 
                         where idPonderacion = @IdPonderacion ";
            var result = await db.ExecuteAsync(sql, new { IdPonderacion = idPonderacion });
            return result > 0;
        }
        public async Task<IEnumerable<Ponderacion>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from ponderacion";
            return await db.QueryAsync<Ponderacion>(sql, new { });
        }
        public async Task<Ponderacion> GetPonderacion(int idPonderacion)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from ponderacion
                        where idPonderacion = @IdPonderacion ";
            return await db.QueryFirstOrDefaultAsync<Ponderacion>(sql, new { IdPonderacion = idPonderacion });
        }
        public async Task<bool> InsertPonderacion(Ponderacion ponderacion)
        {
            var db = dbConnection();
            var sql = @" insert into ponderacion (valor, usuarioCreacion, fechaCreacion)
                        values (@Valor, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            ponderacion.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            ponderacion.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    ponderacion.valor,
                    ponderacion.usuarioCreacion,
                    ponderacion.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdatePonderacion(Ponderacion ponderacion)
        {
            var db = dbConnection();
            var sql = @" update ponderacion 
                         set valor = @Valor,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idPonderacion = @IdPonderacion";


            DateTime fechaActualizacion = DateTime.Now;
            ponderacion.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            ponderacion.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                ponderacion.valor,
                ponderacion.usuarioActualizacion,
                ponderacion.fechaActualizacion,
                ponderacion.idPonderacion
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
