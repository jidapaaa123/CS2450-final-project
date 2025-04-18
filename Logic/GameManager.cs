using System.Dynamic;

namespace Logic;

public class GameManager
{
    const int mapsAmount = 9;

    public List<Map> Maps = new();

    public int CurrentMapIndex;
    public Player Player;

    public GameManager(Player player)
    {
        Player = player;
        CurrentMapIndex = 4; // index of Home

        // For each of the 9 maps, initialize in Maps List
        for (int i = 0; i < mapsAmount; i++)
        {
            Maps.Add(new Map(i, (null, null)));
        }

        // Plop the player at starting place: Home (0,0)
        Maps[CurrentMapIndex].PlayerPosition = (0, 0);

    }

    public void MovePlayer(char input)
    {
        input = char.ToUpper(input);
        (int rowChange, int colChange) = input switch
        {
            'W' => (-1, 0),
            'A' => (0, -1),
            'S' => (1, 0),
            'D' => (0, 1),
            _ => throw new ArgumentException("Movement input invalid: Not WASD"),
        };

        Maps[CurrentMapIndex].Move(rowChange, colChange, out CurrentMapIndex);

        throw new NotImplementedException("figure out player movement display");

    }

}
