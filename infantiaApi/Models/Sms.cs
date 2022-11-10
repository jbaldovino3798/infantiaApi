namespace infantiaApi.Models
{
    public class Sms
    {
        public int idSms { get; set; }
        public int idPerfil { get; set; }
        public string mensaje { get; set; }
        public bool estado { get; set; }
    }
}
