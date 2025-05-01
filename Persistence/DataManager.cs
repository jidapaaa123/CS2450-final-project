using System.Text;

namespace Persistence;

public enum Item
{
    None = -1, Player, Seafood, Carne, Egg, Leche, Fruit, Vegetable, Water, Mineral, Rock,
    Flour, Bread, Steak, Fried_Chicken, Salt, Sugar
}
public class DataManager
{
    private static string storagePath = "../Persistence/data.txt";

    public static void StoreData(Item requestedFood, Queue<Item> Inventory)
    {
        var lines = new string[]
        {
            requestedFood.ToString(),
            StringifyInventory(Inventory)
        };

        File.WriteAllLines(storagePath, lines);
    }

    public static (Item requestedFood, Queue<Item> inventory) LoadData()
    {
        var data = File.ReadAllLines(storagePath);

        Item requestedFood = Enum.Parse<Item>(data[0]);

        Queue<Item> inventory = new();
        string[] items = data[1].Split(',');

        foreach(var item in items)
        {
            inventory.Enqueue(Enum.Parse<Item>(item));
        }

        return (requestedFood, inventory);
    }

    public static string StringifyInventory(Queue<Item> inventory)
    {
        StringBuilder builder = new();
        while(inventory.Count > 0)
        {
            Item item = inventory.Dequeue();
            builder.Append($"{item},");
        }
        
        return builder.ToString().TrimEnd(',');
    }

}
