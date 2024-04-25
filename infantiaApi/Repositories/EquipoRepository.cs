using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using System.Data;
using System.Data.Common;
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
        public async Task<bool> DeleteEquipo(int cedulaMiembro)
        {
            var db = dbConnection();
            var sql = @" delete from equipo 
                         where cedulaMiembro = @CedulaMiembro ";
            var result = await db.ExecuteAsync(sql, new { CedulaMiembro = cedulaMiembro });
            return result > 0;
        }
        public async Task<IEnumerable<Equipo>> GetAll()
        {
            var db = dbConnection();
            var sql = @" Select 
	                        *,
                            (select descripcion from rol where e.idRol = idRol) as rol
                            from equipo e ";
            return await db.QueryAsync<Equipo>(sql, new { });
        }
        public async Task<Equipo> GetEquipo(int cedulaMiembro)
        {
            var db = dbConnection();
            var sql = @" Select *,
                            (select descripcion from rol where e.idRol = idRol) as rol
                            from equipo e where cedulaMiembro = @CedulaMiembro";
            return await db.QueryFirstOrDefaultAsync<Equipo>(sql, new { CedulaMiembro = cedulaMiembro });
        }
        public async Task<ApiResponse> GetOpcionesSistema(int cedulaMiembro)
        {
            var db = dbConnection();
            var contenedoresSql = @"SELECT distinct c.idContenedor as id, 
                                       c.descripcion as title, 
                                       'basic' as type,
                                       c.icono as icon,
                                       c.link
                                FROM equipo e
                                INNER JOIN rol_opcionessistema r ON e.idRol = r.idRol
                                INNER JOIN opcionessistema o ON r.idopcionesSistema = o.idopcionesSistema
                                INNER JOIN contenedor c ON o.idContenedor = c.idContenedor
                                WHERE e.cedulaMiembro = @CedulaMiembro
                                order by c.descripcion"
            ;

            var contenedores = await db.QueryAsync<dynamic>(contenedoresSql, new { CedulaMiembro = cedulaMiembro });

            var response = new ApiResponse
            {
                data = contenedores.ToList()
            };

            /*foreach (var contenedor in contenedores)
            {
                var idContenedor = contenedor.id;

                var opcionesSql = @"SELECT o.idopcionesSistema as id, 
                                        o.idContenedor,
                                        o.descripcion as title, 
                                        'basic' as type,
                                        o.icono as icon,
                                        o.ruta as link
                                FROM equipo e
                                INNER JOIN rol_opcionessistema r ON e.idRol = r.idRol
                                INNER JOIN opcionessistema o ON r.idopcionesSistema = o.idopcionesSistema 
                                WHERE e.cedulaMiembro = @CedulaMiembro
                                AND o.idContenedor = @IdContenedor";

                var opciones = await db.QueryAsync<dynamic>(opcionesSql, new { CedulaMiembro = cedulaMiembro, IdContenedor = idContenedor });

                contenedor.children = opciones;
            }*/
            return response; 
        }
        public async Task<dynamic> GetRoles()
        {
            var db = dbConnection();
            var rolesSql = @"SELECT idRol, descripcion as rol from rol"
            ;

            var roles = await db.QueryAsync<dynamic>(rolesSql);
            return roles;
        }
        public async Task<bool> InsertEquipo(Equipo equipo)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO equipo (cedulaMiembro, 
                                            nombreMiembro, 
                                            ocupacion, 
                                            idRol, 
                                            password, 
                                            token, 
                                            fechaExpiracionToken,
                                            usuarioCreacion,
                                            fechaCreacion)
                        VALUES (@CedulaMiembro, 
                                @NombreMiembro, 
                                @Ocupacion, 
                                @IdRol, 
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
                    equipo.idRol,
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
                             idRol = @IdRol,
                             estado = @Estado,
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
                    equipo.idRol,
                    equipo.estado,
                    equipo.usuarioActualizacion,
                    equipo.fechaActualizacion,
                    equipo.cedulaMiembro
                });
            return result > 0;
        }
        public async Task<string> GenerateAndStoreToken(int cedulaMiembro)
        {
            var equipo = await GetEquipo(cedulaMiembro);
            if (equipo != null)
            {
                // If the token is empty (new user or token refresh), generate a new token
                equipo.token = "";
                if (string.IsNullOrEmpty(equipo.token))
                {
                    // Generate a new JWT token with a unique secret key for this user
                    equipo.token = GenerateJwtToken(cedulaMiembro, "$2a$11$vgbhrGOc1O2MPVSBA7ApFeephjxwfni9Vphqg3J0JtxIqHDrhJX2G", equipo.idRol);
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

                    return equipo.token;
                }
            }
            return "";
        }
        // Generate JWT token with the user's specific secret key
        private string GenerateJwtToken(int cedulaMiembro, string secretKey, int idRol)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, cedulaMiembro.ToString()),
                new Claim(ClaimTypes.Role, idRol.ToString()), // Agrega el idRol al token
                // Add additional claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Set token expiration time
                signingCredentials: creds
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
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

