using System.Dynamic;

namespace Logic;

public class GameManager
{
    const int mapsAmount = 9;

    public List<char[][]> Maps = new List<char[][]>();

    public (int mapIndex, int row, int column) PlayerPosition = (0, 0, 0);

    public GameManager()
    {
        // For each of the 9 maps, initialize arrays in Maps List
        for (int i = 0; i < mapsAmount; i++)
        {
            char[][] map = Terrains.Home();
            Maps.Add(map);
        }

    }

    public void MovePlayer(char input)
    {
        PlayerPosition.row++;
        PlayerPosition.column++;
        throw new NotImplementedException("figure out player movement display");

    }

}
