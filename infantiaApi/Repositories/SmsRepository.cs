using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class SmsRepository : ISms
    {
        private readonly MySQLConfiguration _connectionString;
        public SmsRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> DeleteSms(Sms sms)
        {
            var db = dbConnection();
            var sql = @" delete from sms 
                         where idSms = @IdSms ";
            var result = await db.ExecuteAsync(sql, new { IdSms = sms.idSms });
            return result > 0;
        }

        public async Task<IEnumerable<Sms>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from sms ";
            return await db.QueryAsync<Sms>(sql, new { });
        }

        public async Task<IEnumerable<Sms>> GetAllbyPerfil(int idPerfil)
        {
            var db = dbConnection();
            var sql = @" Select * from sms where idPerfil = @IdPerfil";
            return await db.QueryAsync<Sms>(sql, new { IdPerfil = idPerfil });
        }

        public async Task<Sms> GetSms(int idSms)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from sms
                        where idSms = @IdSms ";
            return await db.QueryFirstOrDefaultAsync<Sms>(sql, new { IdSms = idSms });
        }

        public async Task<bool> InsertSms(Sms sms)
        {
            var db = dbConnection();
            var sql = @" insert into sms (idPerfil, mensaje, estado)
                        values (@IdPerfil, @Mensaje, @Estado) ";
            var result = await db.ExecuteAsync(sql, new
            {
                sms.idPerfil,
                sms.mensaje,
                sms.estado
            });
            return result > 0;
        }

        public async Task<bool> UpdateSms(Sms sms)
        {
            var db = dbConnection();
            var sql = @" update  sms 
                         set idPerfil = @IdPerfil, 
                            mensaje = @Mensaje, 
                            estado = @Estado 
                         where idSms = @IdSms";
            var result = await db.ExecuteAsync(sql, new
            {
                sms.idPerfil,
                sms.mensaje,
                sms.estado,
                sms.idSms
            });
            return result > 0;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
