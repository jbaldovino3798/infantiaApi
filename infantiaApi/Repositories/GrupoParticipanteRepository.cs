using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class GrupoParticipanteRepository : IGrupoParticipante
    {
        private readonly MySQLConfiguration _connectionString;
        public GrupoParticipanteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteGrupoParticipante(GrupoParticipante grupoParticipante)
        {
            var db = dbConnection();
            var sql = @" delete from GrupoParticipante 
                         where idGrupoParticipante = @IdGrupoParticipante ";
            var result = await db.ExecuteAsync(sql, new { IdGrupoParticipante = grupoParticipante.idGrupoParticipante });
            return result > 0;
        }
        public async Task<IEnumerable<GrupoParticipante>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from formulario ";
            return await db.QueryAsync<GrupoParticipante>(sql, new { });
        }
        public async Task<GrupoParticipante> GetGrupoParticipante(int idGrupoParticipante)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from GrupoParticipante
                        where idGrupoParticipante = @IdGrupoParticipante ";
            return await db.QueryFirstOrDefaultAsync<GrupoParticipante>(sql, new { IdGrupoParticipante = idGrupoParticipante });
        }
        public async Task<bool> InsertGrupoParticipante(GrupoParticipante grupoParticipante)
        {
            var db = dbConnection();
            var sql = @" insert into GrupoParticipante (descripcionGrupo, usuarioCreacion, fechaCreacion)
                        values (@DescripcionGrupo, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            grupoParticipante.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            grupoParticipante.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    grupoParticipante.descripcionGrupo,
                    grupoParticipante.usuarioCreacion,
                    grupoParticipante.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateGrupoParticipante(GrupoParticipante grupoParticipante)
        {
            var db = dbConnection();
            var sql = @" update formulario 
                         set descripcionGrupo =  @DescripcionGrupo,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idGrupoParticipante = @IdGrupoParticipante";

            DateTime fechaActualizacion = DateTime.Now;
            grupoParticipante.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            grupoParticipante.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    grupoParticipante.descripcionGrupo,
                    grupoParticipante.usuarioActualizacion,
                    grupoParticipante.fechaActualizacion,
                    grupoParticipante.idGrupoParticipante
                });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
