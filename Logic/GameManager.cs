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
        // Plop the player at starting place: Home (0,0)
        for (int i = 0; i < 4; i++)
        {
            Maps.Add(new Map(i, (null, null)));
        }
        Maps.Add(new Map(4, (0, 0)));
        for (int i = 5; i < mapsAmount; i++)
        {
            Maps.Add(new Map(i, (null, null)));
        }
    }

    public void ProcessAction(Action action)
    {
        if (Player.ActionIsMovement(action))
        {
            processMovement(action);
        }
        else
        {
            throw new NotImplementedException($"Not ready to process action {action}");
        }
    }

    private void processMovement(Action movement)
    {
        (int rowChange, int colChange) = movement switch
        {
            Action.Up => (-1, 0),
            Action.Left => (0, -1),
            Action.Down => (1, 0),
            Action.Right => (0, 1),
            _ => throw new ArgumentException("ProcessMovement(): Action not movement"),
        };

        if (Maps[CurrentMapIndex].WillCollide(rowChange, colChange))
        {
            throw new SolidObjectCollisionException("Movement into solid object not allowed");
        }

        Maps[CurrentMapIndex].Move(rowChange, colChange, out CurrentMapIndex);
    }


}
