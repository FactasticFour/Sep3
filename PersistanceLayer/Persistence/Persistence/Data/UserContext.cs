using Microsoft.EntityFrameworkCore;
using Persistence.Model;

namespace Persistence
{
    public class UserContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=viapay;Username=postgres;Password=9533",
                options => options.UseAdminDatabase("viapay"));
        }
    }
}