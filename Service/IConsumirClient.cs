using Model;

namespace Service.Interfaces
{
    public interface IConsumirClient
    {
        Task<User> GetUsuarioByIdAsync(string id);
    }
}