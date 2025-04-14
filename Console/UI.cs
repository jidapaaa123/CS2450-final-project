using System.Text;

namespace Display;

public class UI
{
    public static char PlayerIcon = 'O';

    public static string DisplayOfMap(char[][] map)
    {
        StringBuilder builder = new();

        
        foreach (char[] chars in map)
        {
            string currentLine = new string(chars);
            builder.AppendLine(currentLine);
        }

        return builder.ToString();
    }
}