using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class ValoracionRepository : IValoracion
    {
        private readonly MySQLConfiguration _connectionString;
        public ValoracionRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<bool> DeleteValoracion(Valoracion valoracion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Valoracion>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Valoracion> GetValoracion(int idValoracion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertValoracion(Valoracion valoracion)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateValoracion(Valoracion valoracion)
        {
            throw new NotImplementedException();
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
