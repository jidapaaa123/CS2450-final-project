using System.Text;

namespace Persistence;

public enum Item
{
    None = -1, Player, Seafood, Carne, Egg, Leche, Fruit, Vegetable, Water, Mineral, Rock,
    Flour, Bread, Steak, Fried_Chicken, Salt, Sugar, Sashimi,
    Steak_Sandwich, Crispy_Chicken_Sandwich, Noodles,
    Waffle, Cornbread, Pancake, Fried_Fish, Garfield_Spaghetti, Raw_Egg_Water
}
public class DataManager
{
    private static string storagePath = "../Persistence/data.txt";

    public static void StoreData(Item requestedFood, List<Item> Inventory)
    {
        var lines = new string[]
        {
            requestedFood.ToString(),
            StringifyInventory(Inventory)
        };

        File.WriteAllLines(storagePath, lines);
    }

    public static (Item requestedFood, List<Item> inventory) LoadData()
    {
        var data = File.ReadAllLines(storagePath);

        Item requestedFood = Enum.Parse<Item>(data[0]);

        List<Item> inventory = new();
        string[] items = data[1].Split(',');

        foreach (var item in items)
        {
            inventory.Add(Enum.Parse<Item>(item));
        }

        return (requestedFood, inventory);
    }

    public static string StringifyInventory(List<Item> inventory)
    {
        StringBuilder builder = new();
        foreach (var item in inventory)
        {
            builder.Append($"{item},");
        }

        return builder.ToString().TrimEnd(',');
    }

}
