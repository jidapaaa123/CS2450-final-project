using System.Text;
using Logic;
using Persistence;

namespace Display;

public class UI
{
    private static List<ConsoleKey> actionInputs = new()
    {
        ConsoleKey.UpArrow,
        ConsoleKey.LeftArrow,
        ConsoleKey.DownArrow,
        ConsoleKey.RightArrow,
        ConsoleKey.W,
        ConsoleKey.A,
        ConsoleKey.S,
        ConsoleKey.D,
        ConsoleKey.E, // Cook
        ConsoleKey.F, // Feed
        ConsoleKey.Escape, // Quit
    };


    public static void PrintScreenHeader(GameManager manager)
    {
        Map map = manager.Maps[manager.CurrentMapIndex];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"Map {map.MapIndex}: {map.TerrainType}");
        Console.WriteLine($"Cat's Request: {manager.RequestedFood.ToString().Replace('_', ' ')}");
        Console.WriteLine($"Inventory: {manager.Player.InventoryAsString()}");
        Console.WriteLine("▪ 'E' to Cook       ▪ 'F' to Feed     ▪ 'esc' to Quit ");


        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void PrintScreenFooter(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"MESSAGE: \n{message}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void PrintMapDisplay(Map mapObject)
    {
        StringBuilder builder = new();

        char[][] map = mapObject.Blocks;
        foreach (char[] chars in map)
        {
            string currentLine = new string(chars);
            builder.AppendLine(currentLine);
        }

        Console.WriteLine(builder);
    }

    public static Logic.Action GetAction()
    {
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (actionInputs.Contains(key))
            {
                return key switch
                {
                    ConsoleKey.UpArrow or ConsoleKey.W => Logic.Action.Up,
                    ConsoleKey.LeftArrow or ConsoleKey.A => Logic.Action.Left,
                    ConsoleKey.DownArrow or ConsoleKey.S => Logic.Action.Down,
                    ConsoleKey.RightArrow or ConsoleKey.D => Logic.Action.Right,
                    ConsoleKey.E => Logic.Action.Cook,
                    ConsoleKey.F => Logic.Action.Feed,
                    ConsoleKey.Escape => Logic.Action.Quit,
                };
            }
        }
    }

    public static void ProcessAction(Logic.Action action, GameManager manager)
    {
        if (Player.ActionIsMovement(action))
        {
            manager.ProcessMovement(action);
        }
        else if (action == Logic.Action.Quit)
        {
            DataManager.StoreData(manager.RequestedFood, manager.Player.Inventory);
            System.Environment.Exit(0);
        }
        else if (action == Logic.Action.Cook)
        {
            ProcessCooking(manager);
        }
        else // Feed
        {
            if (manager.CurrentMapIndex != 4)
            {
                throw new CannotFeedCatException("You must be home (Map 4) to feed your Cat!");
            }

            bool fed = manager.Feed();

            if (!fed)
            {
                throw new CannotFeedCatException($"You don't have {manager.RequestedFood}!");
            }
            else
            {
                throw new HappyCatException("You fed Cat! It's very happy... but has biblical levels of greed\n" +
                                            $"New Requested Food: {manager.RequestedFood.ToString().Replace('_', ' ')}");
            }
        }
    }

    public static void ProcessCooking(GameManager manager)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("KITCHEN");

            Console.WriteLine($"Cat's Request: {manager.RequestedFood}");
            Console.WriteLine($"Inventory: {Player.NumberOfItemsAsString(manager.Player.GetAmountsOfItems())}");
            Console.WriteLine("\nWhat'd you like to make?");

            Console.WriteLine($"0. Nothing... I changed my mind");
            for (int i = 0; i < Kitchen.AllCraftables.Length; i++)
            {
                Item item = Kitchen.AllCraftables[i];
                // This line below is so unreadable but I'm not gonna refactor it
                Console.WriteLine($"{i + 1}. {item.ToString().Replace('_', ' ')} ({Player.NumberOfItemsAsString(Player.OccurrencesOfItem(Kitchen.CraftableRecipes[item]))})");
            }

            int number = GetInt(0, Kitchen.AllCraftables.Length);
            if (number == 0)
            {
                return;
            }
            else
            {
                Item selectedDish = Kitchen.AllCraftables[number - 1];
                bool cooked = manager.Player.Cook(selectedDish);
                PrintCookingResult(selectedDish, cooked);

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey(true);
            }
        }
    }

    public static int GetInt(int min, int max)
    {
        while (true)
        {
            Console.Write("\nEnter number to select: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int num))
            {
                Console.WriteLine("Not a number!\n");
            }
            else if (num >= min && num <= max)
            {
                return num;
            }
            else
            {
                Console.WriteLine($"Must be in [{min}, {max}]!\n");
            }
        }
    }

    public static void PrintCookingResult(Item selectedDish, bool cooked)
    {
        if (!cooked)
        {
            Console.WriteLine("Oh... you're missing some ingredients!");
            return;
        }

        Item[] ingredients = Kitchen.CraftableRecipes[selectedDish];
        Dictionary<Item, int> dict = new();
        foreach (Item item in ingredients)
        {
            if (!dict.ContainsKey(item))
            {
                dict.Add(item, 0);
            }

            dict[item]++;
        }

        Console.WriteLine($" + {selectedDish.ToString().Replace('_', ' ')}");
        foreach (var pair in dict)
        {
            Console.WriteLine($" - {pair.Key} ({pair.Value})");
        }
    }


}