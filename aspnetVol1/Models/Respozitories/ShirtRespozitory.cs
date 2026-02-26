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
}