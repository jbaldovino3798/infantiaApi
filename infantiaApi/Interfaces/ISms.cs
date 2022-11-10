using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ISms
    {
        Task<IEnumerable<Sms>> GetAll();
        Task<IEnumerable<Sms>> GetAllbyPerfil(int idPerfil);
        Task<Sms> GetSms(int idSms);
        Task<bool> InsertSms(Sms sms);
        Task<bool> UpdateSms(Sms sms);
        Task<bool> DeleteSms(Sms sms);
    }
}
