// NOTICE:
// Currently defaulting every map to Home terrain
// PlayerEntersMap() currently deals with Portals by setting player to the (0,0) locaton


namespace Logic;

public class Map
{
    public int MapIndex;
    TerrainType TerrainType;
    public char[][] Blocks
    {
        get
        {
            if (PlayerPosition.row == null || PlayerPosition.column == null)
            {
                return Blocks;
            }

            int row = PlayerPosition.row.Value;
            int column = PlayerPosition.column.Value;
            
            var targetRow = Blocks[]
            return Blocks[] = 
        }
        private set
        {
            Blocks = value;
        }
    }

    public (int? row, int? column) PlayerPosition;

    public Map(int mapIndex, (int?, int?) playerPosition)
    {

        MapIndex = mapIndex;
        TerrainType = TerrainType.Home;
        Blocks = Terrains.Home();

        PlayerPosition = playerPosition;


    }

    public void Move(int rowChange, int colChange, out int destinationMapIndex)
    {
        PlayerPosition.row += rowChange;
        PlayerPosition.column += colChange;

        
        destinationMapIndex = MapIndex;

        if (PlayerPosition.row >= Terrains.Height || PlayerPosition.column >= Terrains.Width)
        {
            throw new NotImplementedException("Player should move to another map, but I didn't code that yet");
        }


    }

    public void PlayerEntersMap(int previousMapIndex, (int row, int column) previousCoordinate)
    {
        PlayerPosition = (0, 0);
    }
}