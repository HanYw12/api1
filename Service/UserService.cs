using Microsoft.EntityFrameworkCore;
using Model;
using Persistencia;

namespace Service.Interfaces
{
    public class UserService : IUserService
    {
        private readonly ContextDb _contextDatabase;
        public UserService(ContextDb contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }
        public async Task<User> GetUser(string identificacionUser)
        {
            try
            {
                var user = await _contextDatabase.User.SingleOrDefaultAsync(u => u.Identificacion == identificacionUser);
                return user!;
            }
            catch
            {
                return null!;
            }
        }
    }
}