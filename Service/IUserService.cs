using Model;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(string identificacion);
        Task<List<User>> GetUsers();
        
    }
}