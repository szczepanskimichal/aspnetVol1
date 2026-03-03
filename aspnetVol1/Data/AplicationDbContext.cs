using Microsoft.EntityFrameworkCore;
using aspnetVol1.Models;

namespace aspnetVol1.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options) // tutaj pokazuje gdzie ta db jest!!!
        {
            
        }
        public DbSet<Shirt> Shirts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
// tutaj dodajemy dane do bazy danych, które będą dostępne od razu po jej utworzeniu, tu moge konfigurowac!!!data seeding!!! 
            modelBuilder.Entity<Shirt>().HasData(
                new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Gender = "Men", Size = 10, Price = 29.99 },
                new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Gender = "Men", Size = 22, Price = 122.88 },
                new Shirt { ShirtId = 3, Brand = "Under Armour", Color = "Green", Gender = "Men", Size = 6, Price = 19.99 },
                new Shirt { ShirtId = 4, Brand = "Puma", Color = "Black", Gender = "Men", Size = 8, Price = 24.99 }
                );
        }
    }
}