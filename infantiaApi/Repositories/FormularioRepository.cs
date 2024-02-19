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
            var sql = @" insert into formulario (descripcion, nroPreguntas, usuarioCreacion, fechaCreacion)
                        values (@Descripcion, @NroPreguntas, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            formulario.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            formulario.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {   formulario.descripcion,
                    formulario.nroPreguntas,
                    formulario.usuarioCreacion,
                    formulario.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateFormulario(Formulario formulario)
        {
            var db = dbConnection();
            var sql = @" update formulario 
                         set descripcion =  @Descripcion,
                             nroPreguntas = @NroPreguntas,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idFormulario = @IdFormulario";

            DateTime fechaActualizacion = DateTime.Now;
            formulario.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            formulario.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    formulario.descripcion,
                    formulario.nroPreguntas,
                    formulario.usuarioActualizacion,
                    formulario.fechaActualizacion,
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
