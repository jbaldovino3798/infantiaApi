using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class FormularioRepository : IFormulario
    {
        private readonly MySQLConfiguration _connectionString;
        public FormularioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteFormulario(Formulario formulario)
        {
            var db = dbConnection();
            var sql = @" delete from formulario 
                         where idFormulario = @IdFormulario ";
            var result = await db.ExecuteAsync(sql, new { IdFormulario = formulario.idFormulario });
            return result > 0;
        }
        public async Task<IEnumerable<Formulario>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from formulario ";
            return await db.QueryAsync<Formulario>(sql, new { });
        }
        public async Task<Formulario> GetFormulario(int idFormulario)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from Formulario
                        where idFormulario = @IdFormulario ";
            return await db.QueryFirstOrDefaultAsync<Formulario>(sql, new { IdFormulario = idFormulario });
        }
        public async Task<bool> InsertFormulario(Formulario formulario)
        {
            var db = dbConnection();
            var sql = @" insert into formulario (descripcion, nroPreguntas)
                        values (@Descripcion, @NroPreguntas) ";
            var result = await db.ExecuteAsync(sql, new
                {   formulario.descripcion,
                    formulario.nroPreguntas
                });
            return result > 0;
        }
        public async Task<bool> UpdateFormulario(Formulario formulario)
        {
            var db = dbConnection();
            var sql = @" update formulario 
                         set descripcion =  @Descripcion,
                             nroPreguntas = @NroPreguntas
                        where idFormulario = @IdFormulario";
            var result = await db.ExecuteAsync(sql, new
                {
                    formulario.descripcion,
                    formulario.nroPreguntas,
                    formulario.idFormulario
                });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
