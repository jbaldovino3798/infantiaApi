namespace infantiaApi.Models
{

    using System.Text.Json.Serialization;
    public class Equipo
    {
        public int cedulaMiembro { get; set; }
        public string nombreMiembro { get; set; }
        public string ocupacion { get; set; }
        public string rol { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
