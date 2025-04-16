using System.Text;
using Logic;

namespace Display;

public class UI
{
    public static char PlayerIcon = 'O';

    public static string DisplayOfMap(Map mapObject)
    {
        StringBuilder builder = new();

        char[][] map = mapObject.Blocks;
        foreach (char[] chars in map)
        {
            string currentLine = new string(chars);
            builder.AppendLine(currentLine);
        }

        return builder.ToString();
    }
}