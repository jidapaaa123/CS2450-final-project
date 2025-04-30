namespace Logic;

public enum Action { Up, Left, Down, Right, Cook, Feed, Toggle_Inventory }

public class Player
{
    public const int InventoryLimit = 10;
    public string Name;
    public List<Item> Inventory = new();

    public Player(string name)
    {
        Name = name;
    }
}