using Persistence;

using System.Text;

namespace Logic;

public enum Action { Up, Left, Down, Right, Cook, Feed, Quit }

public class Player
{
    public const int InventoryLimit = 10;
    public string Name;
    public List<Item> Inventory = new();
    public Dictionary<Item, int> GetAmountsOfItems()
    {
        Dictionary<Item, int> dict = new();
        foreach (Item item in Inventory)
        {
            if (!dict.ContainsKey(item))
            {
                dict.Add(item, 0);
            }

            dict[item]++;
        }

        return dict;
    }


    public Player(string name)
    {
        Name = name;
        Inventory.Add(Item.Water);
    }

    public static bool ActionIsMovement(Action action)
    {
        return new List<Action>() { Action.Up, Action.Left, Action.Down, Action.Right }.Contains(action);
    }

    public string InventoryAsString()
    {
        StringBuilder builder = new();

        for (int i = 0; i < Inventory.Count; i++)
        {
            Item item = Inventory[i];
            builder.Append($"{item}, ");

            if (i % 4 == 0 && i != 0)
            {
                builder.Append("\n\t   ");
            }
        }

        return builder.ToString().TrimEnd().TrimEnd(',');
    }

    public static Dictionary<Item, int> OccurrencesOfItem(Item[] array)
    {
        Dictionary<Item, int> dict = new();
        foreach (Item item in array)
        {
            if (!dict.ContainsKey(item))
            {
                dict.Add(item, 0);
            }

            dict[item]++;
        }

        return dict;
    }


    public static string NumberOfItemsAsString(Dictionary<Item, int> dict)
    {
        StringBuilder builder = new();

        foreach (KeyValuePair<Item, int> pair in dict)
        {
            var item = pair.Key;
            var amount = pair.Value;
            builder.Append($"{item} ({amount}), ");
        }

        return builder.ToString().TrimEnd().TrimEnd(',');
    }

    public void CollectItem(Item item)
    {
        if (item == Item.None)
        {
            return;
        }

        if (Inventory.Count == InventoryLimit)
        {
            Inventory.RemoveAt(0);
        }

        Inventory.Add(item);
    }

    public bool Cook(Item dish)
    {
        Item[] ingredients = Kitchen.CraftableRecipes[dish];
        Dictionary<Item, int> amountsOfItems = GetAmountsOfItems();

        Dictionary<Item, int> amountsOfIngredients = new();
        foreach (Item item in ingredients)
        {
            if (!amountsOfIngredients.ContainsKey(item))
            {
                amountsOfIngredients.Add(item, 0);
            }

            amountsOfIngredients[item]++;
        }


        foreach (var pair in amountsOfIngredients)
        {
            Item item = pair.Key;
            int amount = pair.Value;

            if (!amountsOfItems.ContainsKey(item))
            {
                return false;
            }

            if (amountsOfItems[item] < amount)
            {
                return false;
            }
        }

        // can cook!
        foreach (var pair in amountsOfIngredients)
        {
            Item item = pair.Key;
            int amount = pair.Value;

            for (int i = 0; i < amount; i++)
            {
                Inventory.Remove(item);
            }
        }
        CollectItem(dish);
        return true;
    }
}