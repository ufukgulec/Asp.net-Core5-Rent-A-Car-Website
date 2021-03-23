using CoreAracKiralama.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAracKiralama.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP;Database=CoreAracKiralama;integrated security=true");
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
