using Microsoft.EntityFrameworkCore;
using PersistenceServer.Models;

namespace PersistenceServer.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=hattie.db.elephantsql.com;Port=5432;Database=ezeateiy;Username=ezeateiy;Password=6uR8rdvQCc5r8Eho5SZbxjEcWhxtIUWE",
                options => options.UseAdminDatabase("ezeateiy"));
        }
    }
}