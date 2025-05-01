using System.Text;
using Logic;

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
        ConsoleKey.Q, // Inventory
    };


    public static void PrintScreenHeader(GameManager manager)
    {
        Map map = manager.Maps[manager.CurrentMapIndex];
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"Map {map.MapIndex}: {map.TerrainType}");
        Console.WriteLine($"Inventory: {manager.Player.InventoryAsString()}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void PrintScreenFooter(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"MESSAGE: {message}");
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
            ConsoleKey key = Console.ReadKey().Key;

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
                    ConsoleKey.Q => Logic.Action.Toggle_Inventory,
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
        else
        {
            throw new NotImplementedException($"Not ready to process action {action}");
        }
    }
}