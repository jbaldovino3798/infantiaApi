using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class PreguntaFormularioRepository : IPreguntaFormulario
    {
        private readonly MySQLConfiguration _connectionString;
        public PreguntaFormularioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeletePreguntaFormulario(PreguntaFormulario preguntaFormulario)
        {
            var db = dbConnection();
            var sql = @" delete from preguntaFormulario 
                         where idPregunta = @IdPregunta ";
            var result = await db.ExecuteAsync(sql, new { IdPregunta = preguntaFormulario.idPregunta });
            return result > 0;
        }
        public async Task<IEnumerable<PreguntaFormulario>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from pregunta";
            return await db.QueryAsync<PreguntaFormulario>(sql, new { });
        }
        public async Task<IEnumerable<Pregunta>> GetPreguntasbyFormulario(int idFormulario)
        {
            var db = dbConnection();
            var sql = @" Select p.*
                        from pregunta p
                        inner join pregunta_formulario pf on p.idPregunta = pf.idPregunta
                        where pf.idFormulario = @IdFormulario ";
            return await db.QueryAsync<Pregunta>(sql, new { IdFormulario = idFormulario });
        }
        public async Task<bool> InsertPreguntaFormulario(PreguntaFormulario preguntaFormulario)
        {
            var db = dbConnection();
            var sql = @" insert into preguntaFormulario (idPregunta, idFormulario, usuarioCreacion, fechaCreacion)
                        values (@IdPregunta, @IdFormulario, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            preguntaFormulario.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            preguntaFormulario.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    preguntaFormulario.idPregunta,
                    preguntaFormulario.idFormulario,
                    preguntaFormulario.usuarioCreacion,
                    preguntaFormulario.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdatePreguntaFormulario(PreguntaFormulario preguntaFormulario)
        {
            var db = dbConnection();
            var sql = @" update preguntaFormulario 
                         set idPregunta =  @IdPregunta,
                             idFormulario = @IdFormulario,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idPreguntaFormulario = @IdPreguntaFormulario";

            DateTime fechaActualizacion = DateTime.Now;
            preguntaFormulario.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            preguntaFormulario.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                preguntaFormulario.idPregunta,
                preguntaFormulario.idFormulario,
                preguntaFormulario.usuarioActualizacion,
                preguntaFormulario.fechaActualizacion,
                preguntaFormulario.idPreguntaFormulario
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
