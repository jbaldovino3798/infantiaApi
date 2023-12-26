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
    public class CuidadorRepository: ICuidador
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
        public async Task<IEnumerable<Cuidador>> GetAllbyPerfil(int idPerfil)
        {
            var db = dbConnection();
            var sql = @" Select * from Cuidador where idPerfil = @IdPerfil ";
            return await db.QueryAsync<Cuidador>(sql, new { IdPerfil = idPerfil });
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
                        values (@CedulaCuidador, 
                                @NombreCuidador, 
                                @Edad, 
                                @Direccion, 
                                @Barrio, 
                                @Estrato, 
                                @Telefono, 
                                @Email, 
                                @EstadoCivil, 
                                @ParejaDiferente, 
                                @GrupoEtnico,
                                @NivelEducativo, 
                                @Ocupacion, 
                                @NombreNiño, 
                                @EdadMenor, 
                                @Parentesco, 
                                @FechaNacimientoMenor, 
                                @CodigoMunicipio,
                                @IdGrupo,  
                                @IdGrupoParticipante,  
                                @IdPerfil,
                                @UsuarioCreacion,
                                @FechaCreacion) ";

            DateTime fechaCreacion = DateTime.Now;
            cuidador.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            cuidador.usuarioCreacion = "APPWEB";

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
                  cuidador.edadMenor,
                  cuidador.parentesco,
                  cuidador.fechaNacimientoMenor,
                  cuidador.codigoMunicipio,
                  cuidador.idGrupo,
                  cuidador.idGrupoParticipante,
                  cuidador.idPerfil ,
                  cuidador.usuarioCreacion,
                  cuidador.fechaCreacion
                });
            return result > 0;
        }
        public async Task<bool> UpdateCuidador(Cuidador cuidador)
        {
            var db = dbConnection();
            var sql = @" update cuidador 
                         set nombreCuidador =  @NombreCuidador,
                             edad = @Edad,
                             direccion = @Direccion,
                             barrio = @Barrio,
                             estrato = @Estrato,
                             telefono = @Telefono,
                             email = @Email,
                             estadoCivil = @EstadoCivil,
                             parejaDiferente = @ParejaDiferente,
                             grupoEtnico = @GrupoEtnico,
                             nivelEducativo = @NivelEducativo,
                             ocupacion = @Ocupacion,
                             nombreNiño = @NombreNiño,
                             edadMenor = @EdadMenor,
                             parentesco = @Parentesco,
                             fechaNacimientoMenor = @FechaNacimientoMenor,
                             codigoMunicipio = @CodigoMunicipio,
                             idGrupo = @IdGrupo,
                             idGrupoParticipante = @IdGrupoParticipante,
                             idPerfil = @IdPerfil, 
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                        where cedulaCuidador = @CedulaCuidador";

            DateTime fechaActualizacion = DateTime.Now;
            cuidador.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            cuidador.usuarioActualizacion = "APPWEB";

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
                cuidador.edadMenor,
                cuidador.parentesco,
                cuidador.fechaNacimientoMenor,
                cuidador.codigoMunicipio,
                cuidador.idGrupo,
                cuidador.idGrupoParticipante,
                cuidador.idPerfil,
                cuidador.usuarioActualizacion,
                cuidador.fechaActualizacion,
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
