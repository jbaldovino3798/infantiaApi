namespace infantiaApi.Models
{
    public class Equipo
    {
        public int cedulaMiembro { get; set; }
        public string nombreMiembro { get; set; }
        public string ocupacion { get; set; }
        public int rol { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public DateTime fechaExpiracionToken { get; set; }
    }


}
