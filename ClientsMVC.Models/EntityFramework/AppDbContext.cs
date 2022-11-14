using Microsoft.EntityFrameworkCore;

namespace ClientsMVC.Models.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addressess
        {
            get; set;
        }
    }
}