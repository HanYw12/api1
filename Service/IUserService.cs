using Model;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUser();
    }
}