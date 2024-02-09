using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class PreguntaRepository : IPregunta
    {
        private readonly MySQLConfiguration _connectionString;
        public PreguntaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeletePregunta(Pregunta pregunta)
        {
            var db = dbConnection();
            var sql = @" delete from pregunta 
                         where idPregunta = @IdPregunta ";
            var result = await db.ExecuteAsync(sql, new { IdPregunta = pregunta.idPregunta });
            return result > 0;
        }
        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select *,
                        (select descripcion from tipopregunta where idTipoPregunta = p.idTipoPregunta) tipoPregunta
                        from pregunta p";
            return await db.QueryAsync<dynamic>(sql, new { });
        }
        public async Task<Pregunta> GetPregunta(int idPregunta)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from pregunta
                        where idPregunta = @IdPregunta ";
            return await db.QueryFirstOrDefaultAsync<Pregunta>(sql, new { IdPregunta = idPregunta });
        }
        public async Task<bool> InsertPregunta(Pregunta pregunta)
        {
            var db = dbConnection();
            var sql = @" insert into pregunta (idTipoPregunta,idPonderacion, pregunta, tipoDato, usuarioCreacion, fechaCreacion)
                        values ( @IdTipoPregunta, @IdPonderacion, @Pregunta, @TipoDato, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            pregunta.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            pregunta.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                pregunta.idTipoPregunta,
                pregunta.idPonderacion,
                pregunta.pregunta,
                pregunta.tipoDato,
                pregunta.usuarioCreacion,
                pregunta.fechaCreacion
            });
            return result > 0;
        }
        public async Task<bool> UpdatePregunta(Pregunta pregunta)
        {
            var db = dbConnection();
            var sql = @" update pregunta 
                         set idTipoPregunta =  @IdTipoPregunta,
                             idPonderacion =  @IdPonderacion,
                             pregunta = @Pregunta,
                             tipoDato = @TipoDato,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idPregunta = @IdPregunta";

            DateTime fechaActualizacion = DateTime.Now;
            pregunta.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            pregunta.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                pregunta.idTipoPregunta,
                pregunta.idPonderacion,
                pregunta.pregunta,
                pregunta.tipoDato,
                pregunta.usuarioActualizacion,
                pregunta.fechaActualizacion,
                pregunta.idPregunta
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
