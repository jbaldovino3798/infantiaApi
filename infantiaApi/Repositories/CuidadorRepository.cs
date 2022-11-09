using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;

namespace infantiaApi.Repositories
{
    public class CuidadorRepository: ICuidadorRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public CuidadorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Cuidador>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select * from Cuidador ";
            return await db.QueryAsync<Cuidador>(sql, new { });
        }

        public async Task<Cuidador> GetCuidador(int cedulaCuidador)
        {
            var db = dbConnection();
            var sql = @" Select *
                        from Cuidador
                        where cedulaCuidador = @CedulaCuidador ";
            return await db.QueryFirstOrDefaultAsync<Cuidador>(sql, new { CedulaCuidador = cedulaCuidador });
        }

        public async Task<bool> InsertCuidador(Cuidador cuidador)
        {
            var db = dbConnection();
            var sql = @" insert into cuidador 
                        values (@CedulaCuidador, @NombreCuidador, @Edad, @Direccion, @Barrio, @Estrato, @Telefono, @Email, @EstadoCivil, @ParejaDiferente, @GrupoEtnico,
                                @NivelEducativo, @Ocupacion, @NombreNiño, @Parentesco, @IdPerfil ) ";
            var result = await db.ExecuteAsync(sql, new 
                { cuidador.cedulaCuidador, 
                  cuidador.nombreCuidador, 
                  cuidador.edad, 
                  cuidador.direccion, 
                  cuidador.barrio, 
                  cuidador.estrato, 
                  cuidador.telefono, 
                  cuidador.email,
                  cuidador.estadoCivil, 
                  cuidador.parejaDiferente, 
                  cuidador.grupoEtnico, 
                  cuidador.nivelEducativo, 
                  cuidador.ocupacion, 
                  cuidador.nombreNiño, 
                  cuidador.parentesco, 
                  cuidador.idPerfil 
                });
            return result > 0;
        }

        public async Task<bool> UpdateCuidador(Cuidador cuidador)
        {
            var db = dbConnection();
            var sql = @" update cuidador 
                         set nombreCuidador =  @NombreCuidador
                             edad = @Edad
                             direccion = @Direccion
                             barrio = @Barrio
                             estrato = @Estrato
                             telefono = @Telefono
                             email = @Email
                             estadoCivil = @EstadoCivil
                             parejaDiferente = @ParejaDiferente
                             grupoEtnico = @GrupoEtnico
                             nivelEducativo = @NivelEducativo
                             ocupacion = @Ocupacion
                             nombreNiño = @NombreNiño
                             parentesco = @Parentesco
                             idPerfil = @IdPerfil 
                        where cedulaCuidador = @CedulaCuidador";
            var result = await db.ExecuteAsync(sql, new
            {                
                cuidador.nombreCuidador,
                cuidador.edad,
                cuidador.direccion,
                cuidador.barrio,
                cuidador.estrato,
                cuidador.telefono,
                cuidador.email,
                cuidador.estadoCivil,
                cuidador.parejaDiferente,
                cuidador.grupoEtnico,
                cuidador.nivelEducativo,
                cuidador.ocupacion,
                cuidador.nombreNiño,
                cuidador.parentesco,
                cuidador.idPerfil,
                cuidador.cedulaCuidador
            });
            return result > 0;
        }

        public async Task<bool> DeleteCuidador(Cuidador cuidador)
        {
            var db = dbConnection();
            var sql = @" delete from cuidador 
                         where cedulaCuidador = @CedulaCuidador ";
            var result = await db.ExecuteAsync(sql, new  { CedulaCuidador = cuidador.cedulaCuidador });
            return result > 0;
        }
    }
}
