﻿using Dapper;
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
        public async Task<IEnumerable<dynamic>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select  s.*, 
                        case when s.idGrupo is null then ""General"" else
                        (select descripcionGrupo from grupo where idGrupo = s.idGrupo) END as grupo from sms s;";
            return await db.QueryAsync<dynamic>(sql, new { });
        }
        public async Task<IEnumerable<Sms>> GetAllbyGrupo(int idGrupo)
        {
            var db = dbConnection();
            var sql = @" Select * from sms where idGrupo = @IdGrupo";
            return await db.QueryAsync<Sms>(sql, new { IdGrupo = idGrupo });
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
            var sql = @" insert into sms (idGrupo, mensaje, estado, usuarioCreacion, fechaCreacion)
                        values (@IdGrupo, @Mensaje, @Estado, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            sms.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            sms.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    sms.idGrupo,
                    sms.mensaje,
                    sms.estado,
                    sms.usuarioCreacion,
                    sms.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateSms(Sms sms)
        {
            var db = dbConnection();
            var sql = @" update  sms 
                         set idGrupo = @IdGrupo, 
                            mensaje = @Mensaje, 
                            estado = @Estado ,
                            usuarioActualizacion = @UsuarioActualizacion,
                            fechaActualizacion = @FechaActualizacion
                         where idSms = @IdSms";

            DateTime fechaActualizacion = DateTime.Now;
            sms.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            sms.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    sms.idGrupo,
                    sms.mensaje,
                    sms.estado,
                    sms.usuarioActualizacion,
                    sms.fechaActualizacion,
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
