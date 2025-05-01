// NOTICE:
// Currently defaulting every map to Home terrain
// PlayerEntersMap() currently deals with Portals by setting player to the (0,0) locaton
namespace Logic;



public class Map
{
    public int MapIndex;
    public TerrainType TerrainType;
    public char[][] Blocks;
    public int Height
    {
        get
        {
            return Blocks.Length;
        }
    }
    public int Width
    {
        get
        {
            // Assume map is rectangular
            return Blocks[0].Length;
        }
    }

    public static readonly Dictionary<int, Action[]> HittingWallMovements = new()
    {
        {0, [Action.Up, Action.Left]},
        {1, [Action.Up]},
        {2, [Action.Up, Action.Right]},
        {3, [Action.Left]},
        {4, []},
        {5, [Action.Right]},
        {6, [Action.Down, Action.Left]},
        {7, [Action.Down]},
        {8, [Action.Down, Action.Right]}
    };


    public (int? row, int? column) PlayerPosition;

    public Map(int mapIndex, (int?, int?) playerPosition)
    {
        MapIndex = mapIndex;
        TerrainType = Terrains.MapIndextoTerrainType(MapIndex);
        Blocks = Terrains.GenerateTerrain(TerrainType);

        PlayerPosition = playerPosition;

        if (!PositionIsNull(PlayerPosition))
        {
            Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '@';
        }
    }

    public void MoveWithinMap(int rowChange, int colChange, out Item collectedItem)
    {
        if (PositionIsNull(PlayerPosition))
        {
            throw new NullReferenceException("The game thinks Player is not supposed to be on this Map and, thus, cannot move");
        }

        
        Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '.';

        PlayerPosition.row += rowChange;
        PlayerPosition.column += colChange;

        char symbol = Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value];
        collectedItem = Terrains.GetItemFromSymbol(symbol);
        Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '@';
    }

    public void PlayerLeavesMap()
    {
        (int? oldRow, int? oldCol) = PlayerPosition;
        PlayerPosition = (null, null);
        Blocks[oldRow.Value][oldCol.Value] = '.';
    }

    public void PlayerEntersMap((int? row, int? column) previousCoordinate, Action movementToGetHere, out Item collectedItem)
    {
        if (PositionIsNull(previousCoordinate))
        {
            throw new NullReferenceException("The game thinks your previous coordinate is null. Sorry this is a bug :>");
        }

        switch (movementToGetHere)
        {
            case Action.Up:
                PlayerPosition.column = previousCoordinate.column;
                PlayerPosition.row = Blocks.Length - 1;
                break;
            case Action.Down:
                PlayerPosition.column = previousCoordinate.column;
                PlayerPosition.row = 0;
                break;
            case Action.Left:
                PlayerPosition.row = previousCoordinate.row;
                PlayerPosition.column = Blocks[previousCoordinate.row.Value].Length - 1;
                break;
            case Action.Right:
                PlayerPosition.row = previousCoordinate.row;
                PlayerPosition.column = 0;
                break;
        }

        // report the item that the player just got on
        char symbol = Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value];
        collectedItem = Terrains.GetItemFromSymbol(symbol);
        // step on the item
        Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '@';
    }

    /// <summary>
    /// "Will the player go into a solid block if the game lets him move where he wants?"
    /// </summary>
    /// <param name="desiredDirection"></param>
    /// <returns></returns>
    public bool CanMakeTheMove(Action movement, out int newMapIndex, out int rowChange, out int colChange)
    {
        // default to current one
        newMapIndex = MapIndex;

        if (PositionIsNull(PlayerPosition))
        {
            throw new NullReferenceException("Player can't collide... the game thinks");
        }

        if (!Player.ActionIsMovement(movement))
        {
            throw new ArgumentException("CanMakeTheMove(): Action not movement");
        }


        (rowChange, colChange) = movement switch
        {
            Action.Up => (-1, 0),
            Action.Left => (0, -1),
            Action.Down => (1, 0),
            Action.Right => (0, 1),
        };


        try
        {
            char destination = Blocks[PlayerPosition.row!.Value + rowChange][PlayerPosition.column!.Value + colChange];

            // if it's an item -> player can move into it
            return Terrains.SymbolToItem.ContainsKey(destination);
        }
        catch (IndexOutOfRangeException)
        {
            // Case 1: Hitting the wall
            if (HittingWallMovements[MapIndex].Contains(movement))
            {
                throw new SolidObjectCollisionException("Um... I cannot let you fall off the map");
            }


            // Case 2: Enter new map --> change mapIndex 
            switch (movement)
            {
                case Action.Up:
                    newMapIndex = MapIndex - 3;
                    break;
                case Action.Left:
                    newMapIndex = MapIndex - 1;
                    break;
                case Action.Down:
                    newMapIndex = MapIndex + 3;
                    break;
                case Action.Right:
                    newMapIndex = MapIndex + 1;
                    break;
            }

            // throw new NotImplementedException("Check Map.CanMakeTheMove() to Map switches");
            return true;
        }


    }

    private static bool PositionIsNull((int?, int?) coords)
    {
        return coords.Item1 == null || coords.Item2 == null;
    }
}