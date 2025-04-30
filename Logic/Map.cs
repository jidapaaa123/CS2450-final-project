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

    public (int? row, int? column) PlayerPosition;

    public Map(int mapIndex, (int?, int?) playerPosition)
    {
        MapIndex = mapIndex;
        TerrainType = Terrains.MapIndextoTerrainType(MapIndex);
        Blocks = Terrains.GenerateTerrain(TerrainType);

        PlayerPosition = playerPosition;

        if (!PositionIsNull())
        {
            Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '@';
        }
    }

    public void Move(int rowChange, int colChange, out int destinationMapIndex)
    {
        if (PositionIsNull())
        {
            throw new NullReferenceException("The game thinks Player is not supposed to be on this Map and, thus, cannot move");
        }
        destinationMapIndex = MapIndex;

        // char itemCovered = ItemCoveredByPlayer;
        // (int oldRowNum, int oldColumnNum) = (PlayerPosition.row.Value, PlayerPosition.column.Value);


        Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '.';

        PlayerPosition.row += rowChange;
        PlayerPosition.column += colChange;

        Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value] = '@';

        // char itemToCover = Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value];

        if (PlayerPosition.row >= Height || PlayerPosition.column >= Width)
        {
            throw new NotImplementedException("Player should move to another map, but I didn't code that yet");
        }

        // // "Reveal" the item covered by the Player's previous position:
        // var oldRow = Blocks[oldRowNum];
        // oldRow[oldColumnNum] = ItemCoveredByPlayer;
        // // Update Player's icon to reflect movement
        // var newRow = Blocks[PlayerPosition.row.Value];
        // // newRow[PlayerPosition.column.Value] = PlayerIcon;
        // ItemCoveredByPlayer = itemToCover;
    }

    public void PlayerEntersMap(int previousMapIndex, (int row, int column) previousCoordinate)
    {
        PlayerPosition = (0, 0);
    }

    /// <summary>
    /// "Will the player go into a solid block if the game lets him move where he wants?"
    /// </summary>
    /// <param name="desiredDirection"></param>
    /// <returns></returns>
    public bool WillCollide(int rowChange, int colChange)
    {
        if (PositionIsNull())
        {
            throw new NullReferenceException("Player can't collide... the game thinks");
        }

        char destination = Blocks[PlayerPosition.row!.Value + rowChange][PlayerPosition.column!.Value + colChange];

        // if it's not an "item", then it's a solid block
        // if it's not an item -> player will collide
        return !Terrains.SymbolToItem.ContainsKey(destination);
    }

    private bool PositionIsNull()
    {
        return PlayerPosition.row == null || PlayerPosition.column == null;
    }
}