using System.Text;
using Logic;

namespace Display;

public class UI
{

    public static void PrintScreenHeader(Map map)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------------------");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine($"Map {map.MapIndex}: {map.TerrainType}");
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
}