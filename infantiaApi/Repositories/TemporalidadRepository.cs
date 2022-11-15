using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class TemporalidadRepository : ITemporalidad
    {
        private readonly MySQLConfiguration _connectionString;
        public TemporalidadRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteTemporalidad(Temporalidad temporalidad)
        {
            var db = dbConnection();
            var sql = @" delete from temporalidad 
                         where idTemporalidad = @IdTemporalidad ";
            var result = await db.ExecuteAsync(sql, new { IdTemporalidad = temporalidad.idTemporalidad });
            return result > 0;
        }
        public async Task<IEnumerable<Temporalidad>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from temporalidad ";
            return await db.QueryAsync<Temporalidad>(sql, new { });
        }
        public async Task<Temporalidad> GetTemporalidad(int idTemporalidad)
        {
            var db = dbConnection();
            var sql = @" Select * from temporalidad where idTemporalidad = @IdTemporalidad ";
            return await db.QueryFirstOrDefaultAsync<Temporalidad>(sql, new { IdTemporalidad = idTemporalidad });
        }
        public async Task<bool> InsertTemporalidad(Temporalidad temporalidad)
        {
            var db = dbConnection();
            var sql = @" insert into temporalidad (descripcionTemporalidad)
                        values (@DescripcionTemporalidad) ";
            var result = await db.ExecuteAsync(sql, new
            {
                temporalidad.descripcionTemporalidad
            });
            return result > 0;
        }
        public async Task<bool> UpdateTemporalidad(Temporalidad temporalidad)
        {
            var db = dbConnection();
            var sql = @" update  temporalidad 
                         set descripcionTemporalidad = @DescripcionTemporalidad 
                         where idTemporalidad = @IdTemporalidad";
            var result = await db.ExecuteAsync(sql, new
            {
                temporalidad.descripcionTemporalidad,
                temporalidad.idTemporalidad
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
