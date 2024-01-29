using Dapper;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class GenericRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public GenericRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<dynamic> GetMunicipios()
        {
            var db = dbConnection();
            var municipioSql = @"SELECT codigoMunicipio, descripcion from municipio"
            ;

            var municipios = await db.QueryAsync<dynamic>(municipioSql);
            return municipios;
        }
        public async Task<dynamic> GetGrupos()
        {
            var db = dbConnection();
            var grupoSql = @"SELECT idGrupo, descripcionGrupo from grupo"
            ;

            var grupos = await db.QueryAsync<dynamic>(grupoSql);
            return grupos;
        }
        public async Task<dynamic> GetGruposParticipantes()
        {
            var db = dbConnection();
            var grupoParticipanteSql = @"SELECT idGrupoParticipante, descripcionGrupo from grupoparticipante"
            ;

            var gruposParticipantes = await db.QueryAsync<dynamic>(grupoParticipanteSql);
            return gruposParticipantes;
        }
        public async Task<dynamic> GetPerfiles()
        {
            var db = dbConnection();
            var municipioSql = @"SELECT idPerfil, descripcion from perfil"
            ;

            var municipios = await db.QueryAsync<dynamic>(municipioSql);
            return municipios;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
