using Microsoft.EntityFrameworkCore;
using RegistrationAndLogin.Model;

namespace RegistrationAndLogin.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> User { get; set; }

    }
}
