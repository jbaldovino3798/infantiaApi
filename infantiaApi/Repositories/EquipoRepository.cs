using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
            var sql = @" Select * from equipo where cedulaMiembro = @CedulaMiembro";
            return await db.QueryFirstOrDefaultAsync<Equipo>(sql, new { CedulaMiembro = cedulaMiembro });
        }
        public async Task<bool> InsertEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO equipo (cedulaMiembro, 
                                            nombreMiembro, 
                                            ocupacion, 
                                            rol, 
                                            password, 
                                            token, 
                                            fechaExpiracionToken,
                                            usuarioCreacion,
                                            fechaCreacion)
                        VALUES (@CedulaMiembro, 
                                @NombreMiembro, 
                                @Ocupacion, 
                                @Rol, 
                                @Password, 
                                @Token, 
                                @FechaExpiracionToken,
                                @UsuarioCreacion,
                                @FechaCreacion)";

            // Generate a random token for the new user
            equipo.token = GenerateRandomToken(32); // You can specify the desired token length
            DateTime fechaExpiracion = DateTime.Now.AddHours(1);
            DateTime fechaCreacion = DateTime.Now;
            equipo.fechaExpiracionToken = fechaExpiracion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            equipo.fechaCreacion = fechaCreacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            equipo.usuarioCreacion = "APPWEB";

            // Hash the password before storing it
            equipo.password = HashPassword(equipo.password);

            var result = await db.ExecuteAsync(sql, new
                {
                    equipo.cedulaMiembro,
                    equipo.nombreMiembro,
                    equipo.ocupacion,
                    equipo.rol,
                    equipo.password,
                    equipo.token,
                    equipo.fechaExpiracionToken,
                    equipo.usuarioCreacion,
                    equipo.fechaCreacion
                });

            return result > 0;
        }
        public async Task<bool> UpdateEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @" update  equipo 
                         set nombreMiembro = @NombreMiembro,
                             ocupacion = @Ocupacion,
                             rol = @Rol,
                             usuarioActualizacion = @UsuarioActualizacion,
                             fechaActualizacion = @FechaActualizacion
                         where cedulaMiembro = @CedulaMiembro ";

            DateTime fechaActualizacion = DateTime.Now;
            equipo.fechaActualizacion = fechaActualizacion.ToString("yyyy-MM-dd H:mm:ss"); // Token expiration time
            equipo.usuarioActualizacion = "APPWEB";

            var result = await db.ExecuteAsync(sql, new
                {
                    equipo.nombreMiembro,
                    equipo.ocupacion,
                    equipo.rol,
                    equipo.usuarioActualizacion,
                    equipo.fechaActualizacion,
                    equipo.cedulaMiembro
                });
            return result > 0;
        }
        public async Task<bool> GenerateAndStoreToken(int cedulaMiembro)
        {
            var equipo = await GetEquipo(cedulaMiembro);
            if (equipo != null)
            {
                // If the token is empty (new user or token refresh), generate a new token
                if (string.IsNullOrEmpty(equipo.token))
                {
                    equipo.token = GenerateRandomToken(32); // You can specify the desired token length
                    DateTime fechaExpiracion = DateTime.Now.AddHours(1);
                    equipo.fechaExpiracionToken = fechaExpiracion.ToString("yyyy-MM-dd H:mm:ss"); ; // Token expiration time

                    // Store the token and its expiration date in the database
                    var db = dbConnection();
                    var sql = @"UPDATE equipo 
                        SET token = @Token, fechaExpiracionToken = @FechaExpiracionToken 
                        WHERE cedulaMiembro = @CedulaMiembro";

                    var result = await db.ExecuteAsync(sql, new
                    {
                        Token = equipo.token,
                        FechaExpiracionToken = equipo.fechaExpiracionToken,
                        CedulaMiembro = cedulaMiembro
                    });

                    return result > 0;
                }
            }
            return false;
        }
        private string GenerateRandomToken(int tokenLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var randomBytes = new byte[tokenLength];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            var token = new StringBuilder(tokenLength);
            foreach (byte byteValue in randomBytes)
            {
                token.Append(chars[byteValue % (chars.Length)]);
            }

            return token.ToString();
        }
        public async Task<bool> AuthenticateAsync(int cedulaMiembro, string password)
        {
            var equipo = await GetEquipo(cedulaMiembro);
            if (equipo != null)
            {
                // Check if the token is expired
                if (DateTime.Parse(equipo.fechaExpiracionToken) <= DateTime.UtcNow)
                {
                    // Token is expired; regenerate it
                    await GenerateAndStoreToken(cedulaMiembro); // Await the asynchronous method
                }

                // Password validation logic using BCrypt
                if (VerifyPassword(equipo.password, password))
                {
                    return true; // Token is valid, and password is correct
                }
            }
            return false; // User not found or password is incorrect
        }
        // Hash the password using BCrypt
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        // Verify the password using BCrypt
        private bool VerifyPassword(string hashedPassword, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        
    }
}

