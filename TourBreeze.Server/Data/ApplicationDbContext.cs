using Microsoft.EntityFrameworkCore;
using TourBreeze.Models;

namespace TourBreeze.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Countrie> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("ProductTable");
            modelBuilder.Entity<Product>().ToTable("CountrieTable");
        }
    }
}
