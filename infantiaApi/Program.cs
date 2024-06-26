using infantiaApi;
using infantiaApi.Interfaces;
using infantiaApi.Repositories;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using infantiaApi.Middleware;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // Configura Swagger para usar el esquema de seguridad Bearer
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Introduzca el token JWT de la siguiente manera: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

//Read Connection String
var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<ICuidador, CuidadorRepository>();
builder.Services.AddScoped<IEquipo, EquipoRepository>();
builder.Services.AddScoped<IFormulario, FormularioRepository>();
builder.Services.AddScoped<IGrupo, GrupoRepository>();
builder.Services.AddScoped<IGrupoParticipante, GrupoParticipanteRepository>();
builder.Services.AddScoped<IMunicipio, MunicipioRepository>();
builder.Services.AddScoped<IPerfil, PerfilRepository>();
builder.Services.AddScoped<IPonderacion, PonderacionRepository>();
builder.Services.AddScoped<IPregunta, PreguntaRepository>();
builder.Services.AddScoped<IPreguntaFormulario, PreguntaFormularioRepository>();
builder.Services.AddScoped<IRespTempUsu, RespTempUsuRepository>();
builder.Services.AddScoped<IRespuesta, RespuestaRepository>();
builder.Services.AddScoped<ISms, SmsRepository>();
builder.Services.AddScoped<ITemporalidad, TemporalidadRepository>();
builder.Services.AddScoped<IValoracion, ValoracionRepository>();
builder.Services.AddScoped<ITipoPregunta, TipoPreguntaRepository>();
builder.Services.AddScoped<IConfiguracionTipoPregunta, ConfiguracionTipoPreguntaRepository>();
builder.Services.AddScoped<IReportes, ReportesRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", 
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("token");
var key = Encoding.ASCII.GetBytes(jwtSettings["key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false, // You can set this to true if you want to validate the issuer
            ValidateAudience = false, // You can set this to true if you want to validate the audience
        };
    });

builder.Services.AddAuthorization();

// Configure logging to output to the console
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseMiddleware<JwtMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
