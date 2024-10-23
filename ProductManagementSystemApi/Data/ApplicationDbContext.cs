using Microsoft.EntityFrameworkCore;
using ProductManagementSystemApi.Models;

namespace ProductManagementSystemApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product 
                    { 
                        Id = 1,
                        Name = "Laptop",
                        Description = "Laptop at very cool price"
                     },
                    new Product
                    {
                        Id = 2,
                        Name = "Phone",
                        Description = "Iphone 15 Pro Max"
                    },

                    new Product
                    {
                        Id = 3,
                        Name = "Watch",
                        Description = "High Quality Watch "
                    }
                );
        }
    }
}
