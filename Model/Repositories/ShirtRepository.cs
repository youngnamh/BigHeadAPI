namespace BigHeadAPI.Model.Repositories;

public class ShirtRepository
{
    private static List<Shirt> shirts = new List<Shirt>
    {
        new Shirt { ShirtId = 1, Brand = "Nike", Color = "Blue", Price = 29.99, Size = 8 },
        new Shirt { ShirtId = 2, Brand = "Adidas", Color = "Red", Price = 24.99, Size = 7 },
        new Shirt { ShirtId = 3, Brand = "Puma", Color = "Green", Price = 19.99, Size = 6 },
        new Shirt { ShirtId = 4, Brand = "Under Armour", Color = "Black", Price = 34.99, Size = 8 },
        new Shirt { ShirtId = 5, Brand = "Reebok", Color = "White", Price = 27.99, Size = 5 }
    };

    public static bool ShirtExists(int id)
    {
        return shirts.Any(x => x.ShirtId == id);
    }

    public static Shirt? GetShirtById(int id)
    {
        return shirts.FirstOrDefault(x => x.ShirtId == id);
    }
}