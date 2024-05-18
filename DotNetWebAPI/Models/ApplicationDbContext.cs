using DotNetWebAPI.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        //Seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Mouse",
                    Description = "Lenovo Mouse",
                    Price = 2000
                },
                new Product
                {
                    Id=2,
                    Name="LED",
                    Description="Dell Led",
                    Price=50000
                }

            );
        }
    }
}
