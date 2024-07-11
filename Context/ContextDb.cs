using Microsoft.EntityFrameworkCore;
using Model;

namespace Persistencia
{
    public class ContextDb : DbContext
    {
        public ContextDb() { }
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}
