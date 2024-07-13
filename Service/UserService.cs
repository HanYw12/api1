using Microsoft.EntityFrameworkCore;
using Model;
using Persistencia;

namespace Service.Interfaces
{
    public class UserService : IUserService
    {
        private readonly ContextDb _contextDatabase;
        private readonly ConsumirClient _consumirClient;

        public UserService(ContextDb contextDatabase, ConsumirClient consumirClient)
        {
            _contextDatabase = contextDatabase;
            _consumirClient = consumirClient;
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
        public async Task<User?> GetUserbyIdentificacion(string identificacionUser)
        {
            try
            {
                var user = await _contextDatabase.User.SingleOrDefaultAsync(u => u.Identificacion == identificacionUser);
                if (user == null)
                {
                    // Aquí puedes realizar alguna acción adicional si el usuario no se encuentra en la base de datos
                    // Por ejemplo, podrías llamar a un cliente externo para obtener el usuario
                    var externalUser = await _consumirClient.GetUsuarioByIdAsync(identificacionUser);
                    // Si obtienes el usuario del cliente externo, podrías guardarlo en la base de datos
                    if (externalUser != null)
                    {
                        var newUser = new User
                        {
                            Identificacion = externalUser.Identificacion,
                            Nombres = externalUser.Nombres,
                            Apellidos = externalUser.Apellidos,
                            Telefono = externalUser.Telefono,
                            Email = externalUser.Email
                        };
                        _contextDatabase.User.Add(newUser);
                        await _contextDatabase.SaveChangesAsync();
                        return newUser;
                    }
                }

                return user;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                // Por ejemplo, podrías registrar el error
                // _logger.LogError(ex, "Error al obtener el usuario por identificación");
                return null;
            }
        }


    }
}