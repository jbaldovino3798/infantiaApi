using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class CuidadorFormularioRepository : ICuidadorFormulario
    {
        private readonly MySQLConfiguration _connectionString;
        public CuidadorFormularioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> DeleteCuidadorFormulario(CuidadorFormulario cuidadorFormulario)
        {
            var db = dbConnection();
            var sql = @" delete from cuidador_formulario 
                         where cedulaCuidador = @CedulaCuidador 
                         and idFormulario = @IdFormulario ";
            var result = await db.ExecuteAsync(sql, new { 
                CedulaCuidador = cuidadorFormulario.cedulaCuidador, 
                IdFormulario = cuidadorFormulario.idFormulario
            });
            return result > 0;
        }

        public async Task<IEnumerable<CuidadorFormulario>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from cuidador_formulario ";
            return await db.QueryAsync<CuidadorFormulario>(sql, new { });
        }

        public async Task<IEnumerable<CuidadorFormulario>> GetAllbyCuidador(int cedulaCuidador)
        {
            var db = dbConnection();
            var sql = @" Select * from cuidador_formulario where cedulaCuidador = @CedulaCuidador ";
            return await db.QueryAsync<CuidadorFormulario>(sql, new { CedulaCuidador = cedulaCuidador });
        }

        public async Task<IEnumerable<CuidadorFormulario>> GetAllbyFormulario(int idFormulario)
        {
            var db = dbConnection();
            var sql = @" Select * from cuidador_formulario where idFormulario = @IdFormulario ";
            return await db.QueryAsync<CuidadorFormulario>(sql, new { IdFormulario = idFormulario });
        }

        public async Task<CuidadorFormulario> GetCuidadorFormulario(int cedulaCuidador, int idFormulario)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from cuidador_formulario
                        where cedulaCuidador = @CedulaCuidador
                        and idFormulario = @IdFormulario ";
            return await db.QueryFirstOrDefaultAsync<CuidadorFormulario>(sql, new { 
                CedulaCuidador = cedulaCuidador,
                IdFormulario = idFormulario
            });
        }

        public async Task<bool> InsertCuidadorFormulario(CuidadorFormulario cuidadorFormulario)
        {
            var db = dbConnection();
            var sql = @" insert into cuidador_formulario (cedulaCuidador, idFormulario, fecha)
                        values (@CedulaCuidador, @IdFormulario, @Fecha) ";
            var result = await db.ExecuteAsync(sql, new
            {
                cuidadorFormulario.cedulaCuidador,
                cuidadorFormulario.idFormulario,
                cuidadorFormulario.fecha
            });
            return result > 0;
        }

        public async Task<bool> UpdateCuidadorFormulario(CuidadorFormulario cuidadorFormulario)
        {
            var db = dbConnection();
            var sql = @" update cuidador_formulario 
                         set fecha =  @Fecha
                        where cedulaCuidador = @CedulaCuidador
                        and idFormulario = @IdFormulario ";
            var result = await db.ExecuteAsync(sql, new
            {
                cuidadorFormulario.fecha,
                cuidadorFormulario.cedulaCuidador,
                cuidadorFormulario.idFormulario
            });
            return result > 0;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

    }
}
