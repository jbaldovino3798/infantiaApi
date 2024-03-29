﻿using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly MySQLConfiguration _connectionString;
        public PerfilRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<bool> DeletePerfil(Perfil perfil)
        {
            var db = dbConnection();
            var sql = @" delete from perfil 
                         where idPerfil = @IdPerfil ";
            var result = await db.ExecuteAsync(sql, new { IdPerfil = perfil.idPerfil });
            return result > 0;
        }
        public async Task<IEnumerable<Perfil>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from perfil ";
            return await db.QueryAsync<Perfil>(sql, new { });
        }
        public async Task<Perfil> GetPerfil(int idPerfil)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from perfil
                        where idPerfil = @IdPerfil ";
            return await db.QueryFirstOrDefaultAsync<Perfil>(sql, new { IdPerfil = idPerfil });
        }
        public async Task<bool> InsertPerfil(Perfil perfil)
        {
            var db = dbConnection();
            var sql = @" insert into perfil (descripcion, usuarioCreacion, fechaCreacion)
                        values (@Descripcion, @UsuarioCreacion, @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            perfil.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            perfil.usuarioCreacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    perfil.descripcion,
                    perfil.usuarioCreacion,
                    perfil.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdatePerfil(Perfil perfil)
        {
            var db = dbConnection();
            var sql = @" update perfil 
                         set descripcion =  @Descripcion,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where idPerfil = @IdPerfil ";

            DateTime fechaActualizacion = DateTime.Now;
            perfil.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            perfil.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
            {
                perfil.descripcion,
                perfil.usuarioActualizacion,
                perfil.fechaActualizacion,
                perfil.idPerfil
            });
            return result > 0;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
