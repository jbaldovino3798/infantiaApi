using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface ISms
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<IEnumerable<Sms>> GetAllbyGrupo(int idGrupo);
        Task<Sms> GetSms(int idSms);
        Task<bool> InsertSms(Sms sms);
        Task<bool> UpdateSms(Sms sms);
        Task<bool> DeleteSms(Sms sms);
    }
}
