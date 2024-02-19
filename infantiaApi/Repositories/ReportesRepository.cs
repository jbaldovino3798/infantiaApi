using Dapper;
using infantiaApi.Interfaces;
using infantiaApi.Models;
using MySql.Data.MySqlClient;
using System.Dynamic;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace infantiaApi.Repositories
{
    public class ReportesRepository : IReportes
    {
        private readonly MySQLConfiguration _connectionString;
        public ReportesRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<dynamic>> GetReportes()
        {
            var db = dbConnection();
            var sql = @" Select  idReporte, nombre, parametros from reportes ";
            return await db.QueryAsync<dynamic>(sql, new { });
        }
        public async Task<string> GetReporte(int idReporte, string parametrosJson)
        {
            var db = dbConnection();
            // Obtener el SQL del reporte
            var sqlQuery = await GetReportSqlQuery(idReporte);

            // Convertir el JSON de parámetros a un objeto dinámico si es necesario
            IDictionary<string, object> dynamicParameters = new ExpandoObject();

            // Verificar si se proporcionaron parámetros y, si es así, convertirlos a un objeto dinámico
            if (!string.IsNullOrEmpty(parametrosJson))
            {
                using (JsonDocument document = JsonDocument.Parse(parametrosJson))
                {
                    JsonElement root = document.RootElement;

                    // Asignar los parámetros al objeto dinámico
                    foreach (JsonProperty property in root.EnumerateObject())
                    {
                        // Convertir el nombre del parámetro a la convención de la consulta SQL
                        var nombreParametroSql = property.Name.Substring(0, 1).ToUpper() + property.Name.Substring(1);
                        dynamicParameters[nombreParametroSql] = GetValueFromJsonElement(property.Value);
                    }
                }
            }

            Console.WriteLine($"query: {sqlQuery}");

            // Ejecutar la consulta con Dapper con parámetros
            var records = await db.QueryAsync<dynamic>(sqlQuery, dynamicParameters);

            // Convertir los registros a formato CSV
            using (var writer = new StringWriter())
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(records);
                return writer.ToString();
            }
        }
        private object GetValueFromJsonElement(JsonElement jsonElement)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Number:
                    return jsonElement.GetInt32();
                case JsonValueKind.String:
                    return jsonElement.GetString();
                // Agrega otros casos según sea necesario (por ejemplo, para booleanos, arrays, etc.)
                default:
                    throw new InvalidOperationException("Tipo de valor JSON no compatible.");
            }
        }

        private async Task<string> GetReportSqlQuery(int idReporte)
        {
            var db = dbConnection();
            var sql = "SELECT query FROM reportes WHERE idReporte = @IdReporte";
            return await db.QueryFirstOrDefaultAsync<string>(sql, new { IdReporte = idReporte });
        }
        /*public async Task<IEnumerable<dynamic>> GetReporte(int idReporte)
        {
            var db = dbConnection();
            var sql = @" Select query from reportes where idReporte = @IdReporte";
            return await db.QueryAsync<dynamic>(sql, new { IdReporte = idReporte });

        }*/


        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
    }
}
