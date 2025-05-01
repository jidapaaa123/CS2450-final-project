using System.Text;

namespace Logic;

public enum Action { Up, Left, Down, Right, Cook, Feed, Toggle_Inventory }

public class Player
{
    public const int InventoryLimit = 10;
    public string Name;
    public Queue<Item> Inventory = new();

    public Player(string name)
    {
        Name = name;
        Inventory.Enqueue(Item.Water);
    }

    public static bool ActionIsMovement(Action action)
    {
        return new List<Action>() { Action.Up, Action.Left, Action.Down, Action.Right }.Contains(action);
    }

    public string InventoryAsString()
    {
        StringBuilder builder = new();

        foreach(var item in Inventory)
        {
            builder.Append($"{item}, ");
        }
        
        return builder.ToString().TrimEnd(' ').TrimEnd(',');
    }

    public void CollectItem(Item item)
    {
        if (item == Item.None)
        {
            return;
        }

        if (Inventory.Count == InventoryLimit)
        {
            Inventory.Dequeue();
        }

        Inventory.Enqueue(item);

    }
}