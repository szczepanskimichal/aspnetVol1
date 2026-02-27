namespace aspnetVol1.Models.Respozitories;

public class ShirtRespozitory
{
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt { ShirtId = 1, Brand = "Nike", Color = "Red", Gender = "Men", Size = 10, Price = 29.99 },
            new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Blue", Gender = "Men", Size = 22, Price = 122.88 },
            new Shirt { ShirtId = 3, Brand = "Under Armour", Color = "Green", Gender = "Men", Size = 6, Price = 19.99 },
            new Shirt { ShirtId = 4, Brand = "Puma", Color = "Black", Gender = "Men", Size = 8, Price = 24.99 }
        };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }
        public static bool ShirtExists(int id)
        {
            return shirts.Any(x=>x.ShirtId == id);
        }
        
        public static Shirt GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? color, int? size, string? gender)
        {
            return shirts.FirstOrDefault(x => 
                !string.IsNullOrWhiteSpace(brand) && 
                !string.IsNullOrWhiteSpace(x.Brand) && 
                x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(color) &&
                !string.IsNullOrWhiteSpace(x.Color) &&
                x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue &&
                x.Size.HasValue &&
                size.Value == x.Size.Value);
        }
        
        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color= shirt.Color;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Price = shirt.Price;
        }

        public static void DeleteShirt(int shirtId)
        {
            var shirt = GetShirtById(shirtId);
            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
        }
}