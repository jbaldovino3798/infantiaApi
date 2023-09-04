using infantiaApi;
using infantiaApi.Interfaces;
using infantiaApi.Repositories;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Read Connection String
var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddScoped<ICuidador, CuidadorRepository>();
builder.Services.AddScoped<IFormulario, FormularioRepository>();
builder.Services.AddScoped<IPregunta, PreguntaRepository>();
builder.Services.AddScoped<IRespuesta, RespuestaRepository>();
builder.Services.AddScoped<ISms, SmsRepository>();
builder.Services.AddScoped<ITemporalidad, TemporalidadRepository>();
builder.Services.AddScoped<ICuidadorFormulario, CuidadorFormularioRepository>();
builder.Services.AddScoped<IValoracion, ValoracionRepository>();
builder.Services.AddScoped<IEquipo, EquipoRepository>();
builder.Services.AddScoped<IPerfil, PerfilRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", 
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.MapPost("/Files/UploadFiles", (HttpRequest request) => {
    if (!request.HasFormContentType)
        return Results.Problem();

    if (!request.Form.Files.Any())
        return Results.BadRequest("Suba al menos un archivo.");
        foreach (var file in request.Form.Files)
        {
            using (var stream = new FileStream(@"C:\Users\jbaldovino\Documents\DocumentosInfantia\" + file.FileName, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }
        return Results.Ok("Archivo Subido Exitosamente");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
