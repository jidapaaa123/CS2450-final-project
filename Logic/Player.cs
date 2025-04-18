namespace Logic;

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