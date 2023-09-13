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
        public async Task<IEnumerable<Pregunta>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from pregunta";
            return await db.QueryAsync<Pregunta>(sql, new { });
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
            var sql = @" insert into pregunta (idPonderacion, pregunta, tipoDato, usuarioCreacion, fechaCreacion)
                        values (@IdPonderacion, @Pregunta, @TipoDato, @UsuarioCreacion, @FechaCreacion) ";
            var result = await db.ExecuteAsync(sql, new
                {
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
                         set idPonderacion =  @IdPonderacion,
                             pregunta = @Pregunta,
                             tipoDato = @TipoDato,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion,
                        where idPregunta = @IdPregunta";
            var result = await db.ExecuteAsync(sql, new
            {
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
