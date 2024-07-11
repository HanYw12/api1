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
        public async Task<List<User>> GetUser()
        {
            try
            {
                var result = await _contextDatabase.User.ToListAsync();
                return result;
            }
            catch
            {

                return null!;
            }
        }
    }
}