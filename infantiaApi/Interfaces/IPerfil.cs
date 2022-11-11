using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IPerfil
    {
        Task<IEnumerable<Perfil>> GetAll();
        Task<Perfil> GetPerfil(int idPerfil);
        Task<bool> InsertPerfil(Perfil perfil);
        Task<bool> UpdatePerfil(Perfil perfil);
        Task<bool> DeletePerfil(Perfil perfil);
    }
}
