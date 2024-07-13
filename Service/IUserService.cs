using Model;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUser();
        Task<User?> GetUserbyIdentificacion(string identificacion);
    }
}