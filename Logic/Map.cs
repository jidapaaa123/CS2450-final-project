// NOTICE:
// Currently defaulting every map to Home terrain
// PlayerEntersMap() currently deals with Portals by setting player to the (0,0) locaton


namespace Logic;

public class Map
{
    public int MapIndex;
    public TerrainType TerrainType;
    public char[][] Blocks;

    public (int? row, int? column) PlayerPosition;

    public Map(int mapIndex, (int?, int?) playerPosition)
    {
        MapIndex = mapIndex;
        TerrainType = Terrains.MapIndextoTerrainType(MapIndex);
        Blocks = Terrains.GenerateTerrain(TerrainType);

        PlayerPosition = playerPosition;
    }

    // public void Move(int rowChange, int colChange, out int destinationMapIndex)
    // {
    //     if (PlayerPosition.row == null || PlayerPosition.column == null)
    //     {
    //         throw new NullReferenceException("The game thinks Player is not supposed to be on this Map and, thus, cannot move");
    //     }
    //     destinationMapIndex = MapIndex;

    //     char itemCovered = ItemCoveredByPlayer;
    //     (int oldRowNum, int oldColumnNum) = (PlayerPosition.row.Value, PlayerPosition.column.Value);

    //     PlayerPosition.row += rowChange;
    //     PlayerPosition.column += colChange;

    //     char itemToCover = Blocks[PlayerPosition.row.Value][PlayerPosition.column.Value];

    //     if (PlayerPosition.row >= Terrains.Height || PlayerPosition.column >= Terrains.Width)
    //     {
    //         throw new NotImplementedException("Player should move to another map, but I didn't code that yet");
    //     }

    //     // "Reveal" the item covered by the Player's previous position:
    //     var oldRow = Blocks[oldRowNum];
    //     oldRow[oldColumnNum] = ItemCoveredByPlayer;
    //     // Update Player's icon to reflect movement
    //     var newRow = Blocks[PlayerPosition.row.Value];
    //     // newRow[PlayerPosition.column.Value] = PlayerIcon;
    //     ItemCoveredByPlayer = itemToCover;
    // }

    public void PlayerEntersMap(int previousMapIndex, (int row, int column) previousCoordinate)
    {
        PlayerPosition = (0, 0);
    }

}