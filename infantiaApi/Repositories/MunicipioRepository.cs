using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class MunicipioRepository : IMunicipio
    {
        private readonly MySQLConfiguration _connectionString;
        public MunicipioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeleteMunicipio(Municipio municipio)
        {
            var db = dbConnection();
            var sql = @" delete from Municipio 
                         where codigoMunicipio = @CodigoMunicipio ";
            var result = await db.ExecuteAsync(sql, new { CodigoMunicipio = municipio.codigoMunicipio });
            return result > 0;
        }
        public async Task<IEnumerable<Municipio>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from Municipio ";
            return await db.QueryAsync<Municipio>(sql, new { });
        }
        public async Task<Municipio> GetMunicipio(string codigoMunicipio)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from Grupo
                        where codigoMunicipio = @CodigoMunicipio ";
            return await db.QueryFirstOrDefaultAsync<Municipio>(sql, new { CodigoMunicipio = codigoMunicipio });
        }
        public async Task<bool> InsertMunicipio(Municipio municipio)
        {
            var db = dbConnection();
            var sql = @" insert into Municipio (codigoMunicipio, descripcion, usuarioCreacion, fechaCreacion)
                        values (@CodigoMunicipio, @Descripcion, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            municipio.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            municipio.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                municipio.codigoMunicipio,
                municipio.descripcion,
                municipio.usuarioCreacion,
                municipio.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateMunicipio(Municipio municipio)
        {
            var db = dbConnection();
            var sql = @" update Municipio 
                         set descripcion =  @Descripcion,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where codigoMunicipio = @CodigoMunicipio";

            DateTime fechaActualizacion = DateTime.Now;
            municipio.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            municipio.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    municipio.descripcion,
                    municipio.usuarioActualizacion,
                    municipio.fechaActualizacion,
                    municipio.codigoMunicipio
                });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
