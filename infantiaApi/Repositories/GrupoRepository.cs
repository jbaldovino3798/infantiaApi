using Dapper;
using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class GrupoRepository : IGrupo
    {
        private readonly MySQLConfiguration _connectionString;
        public GrupoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteGrupo(Grupo grupo)
        {
            var db = dbConnection();
            var sql = @" delete from Grupo 
                         where idGrupo = @IdGrupo ";
            var result = await db.ExecuteAsync(sql, new { IdGrupo = grupo.idGrupo });
            return result > 0;
        }
        public async Task<IEnumerable<Grupo>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from Grupo ";
            return await db.QueryAsync<Grupo>(sql, new { });
        }
        public async Task<Grupo> GetGrupo(int idGrupo)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from Grupo
                        where idGrupo = @IdGrupo ";
            return await db.QueryFirstOrDefaultAsync<Grupo>(sql, new { IdGrupo = idGrupo });
        }
        public async Task<bool> InsertGrupo(Grupo grupo)
        {
            var db = dbConnection();
            var sql = @" insert into Grupo (descripcionGrupo, rangoMinimo, rangoMaximo, usuarioCreacion, fechaCreacion)
                        values (@DescripcionGrupo, @RangoMinimo, @RangoMaximo, @UsuarioCreacion, @FechaCreacion) ";
            var result = await db.ExecuteAsync(sql, new
                {   grupo.descripcionGrupo,
                    grupo.rangoMinimo,
                    grupo.rangoMaximo,
                    grupo.usuarioCreacion,
                    grupo.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateGrupo(Grupo grupo)
        {
            var db = dbConnection();
            var sql = @" update Grupo 
                         set descripcionGrupo =  @DescripcionGrupo,
                             rangoMinimo = @RangoMinimo
                             rangoMaximo = @RangoMaximo,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idGrupo = @IdGrupo";
            var result = await db.ExecuteAsync(sql, new
                {
                    grupo.descripcionGrupo,
                    grupo.rangoMinimo,
                    grupo.rangoMaximo,
                    grupo.usuarioActualizacion,
                    grupo.fechaActualizacion,
                    grupo.idGrupo
                });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
