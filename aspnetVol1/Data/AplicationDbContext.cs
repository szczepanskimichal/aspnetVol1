using Microsoft.EntityFrameworkCore;
using aspnetVol1.Models;

namespace aspnetVol1.Data
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Gender = "Men", Size = 10, Price = 29.99 },
                new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Gender = "Men", Size = 22, Price = 122.88 },
                new Shirt { ShirtId = 3, Brand = "Under Armour", Color = "Green", Gender = "Men", Size = 6, Price = 19.99 },
                new Shirt { ShirtId = 4, Brand = "Puma", Color = "Black", Gender = "Men", Size = 8, Price = 24.99 }
                );
        }
    }
}