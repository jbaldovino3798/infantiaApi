using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace infantiaApi.Middleware;
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private const string SecretKey = "$2a$11$vgbhrGOc1O2MPVSBA7ApFeephjxwfni9Vphqg3J0JtxIqHDrhJX2G"; // Reemplaza esto con tu clave secreta

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Set clock skew to zero so tokens expire exactly at token expiration time
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                // Si llegamos aquí, el token es válido
            }
            catch
            {
                // La validación del token falló
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token inválido");
                return;
            }
        }

        await _next(context);
    }
}