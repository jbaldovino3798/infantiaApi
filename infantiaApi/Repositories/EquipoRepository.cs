using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class EquipoRepository : IEquipo
    {
        private readonly MySQLConfiguration _connectionString;
        public EquipoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @" delete from equipo 
                         where cedulaMiembro = @CedulaMiembro ";
            var result = await db.ExecuteAsync(sql, new { CedulaMiembro = equipo.cedulaMiembro });
            return result > 0;
        }
        public async Task<IEnumerable<Equipo>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from equipo ";
            return await db.QueryAsync<Equipo>(sql, new { });
        }
        public async Task<Equipo> GetEquipo(int cedulaMiembro)
        {
            var db = dbConnection();
            var sql = @" Select * from equipo where cedulaMiembro = @CedulaMiembro ";
            return await db.QueryFirstOrDefaultAsync<Equipo>(sql, new { CedulaMiembro = cedulaMiembro });
        }
        public async Task<bool> InsertEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @" insert into equipo (nombreMiembro, ocupacion, rol)
                        values (@NombreMiembro, @Ocupacion, @Rol) ";
            var result = await db.ExecuteAsync(sql, new
            {
                equipo.nombreMiembro,
                equipo.ocupacion,
                equipo.rol
            });
            return result > 0;
        }
        public async Task<bool> UpdateEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @" update  equipo 
                         set nombreMiembro = @NombreMiembro,
                             ocupacion = @Ocupacion,
                             rol = @Rol
                         where cedulaMiembro = @CedulaMiembro ";
            var result = await db.ExecuteAsync(sql, new
            {
                equipo.nombreMiembro,
                equipo.ocupacion,
                equipo.rol,
                equipo.cedulaMiembro
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
