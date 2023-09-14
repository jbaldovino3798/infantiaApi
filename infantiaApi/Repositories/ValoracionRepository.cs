using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class ValoracionRepository : IValoracion
    {
        private readonly MySQLConfiguration _connectionString;
        public ValoracionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteValoracion(Valoracion valoracion) 
        {
            var db = dbConnection();
            var sql = @" delete from valoracion 
                         where idValoracion = @IdValoracion ";
            var result = await db.ExecuteAsync(sql, new { IdValoracion = valoracion.idValoracion });
            return result > 0;
        }
        public async Task<IEnumerable<Valoracion>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from valoracion ";
            return await db.QueryAsync<Valoracion>(sql, new { });
        }
        public async Task<Valoracion> GetValoracion(int idValoracion)
        {
            var db = dbConnection();
            var sql = @" Select * from valoracion where idValoracion = @IdValoracion ";
            return await db.QueryFirstOrDefaultAsync<Valoracion>(sql, new { IdValoracion = idValoracion });
        }
        public async Task<bool> InsertValoracion(Valoracion valoracion)
        {
            var db = dbConnection();
            var sql = @" insert into valoracion (valor, usuarioCreacion, fechaCreacion)
                        values (@Valor, @UsuarioCreacion, @FechaCreacion) ";
            var result = await db.ExecuteAsync(sql, new
            {
                valoracion.valor,
                valoracion.usuarioCreacion,
                valoracion.fechaCreacion
            });
            return result > 0;
        }
        public async Task<bool> UpdateValoracion(Valoracion valoracion)
        {
            var db = dbConnection();
            var sql = @" update  valoracion 
                         set valor = @Valor 
                         where idValoracion = @IdValoracion";
            var result = await db.ExecuteAsync(sql, new
            {
                valoracion.valor,
                valoracion.idValoracion
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
