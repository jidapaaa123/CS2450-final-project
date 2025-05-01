using Persistence;

namespace Logic;

public enum TerrainType { Home, Forest, River, Mountain_Cave, Timmy_Ranch, Town_Market }


/// <summary>
/// Record of Terrain templates to choose from
/// Returns 2D arrays of the Terrain template
/// Template: Fixed items only, NO portals 
/// </summary>
public static class Terrains
{
    // % of each block spawning an item
    public const int ItemChance = 5;

    private static readonly Dictionary<int, TerrainType> IndexToTerrainType = new Dictionary<int, TerrainType>
    {
        { 0, TerrainType.Forest },
        { 1, TerrainType.River },
        { 2, TerrainType.Mountain_Cave },
        { 3, TerrainType.River },
        { 4, TerrainType.Home },
        { 5, TerrainType.Forest },
        { 6, TerrainType.Timmy_Ranch },
        { 7, TerrainType.Timmy_Ranch },
        { 8, TerrainType.Town_Market }
    };
    public static TerrainType MapIndextoTerrainType(int index)
    {
        if (IndexToTerrainType.TryGetValue(index, out TerrainType terrain))
        {
            return terrain;
        }
        else
        {
            throw new ArgumentException($"Invalid map index: {index}");
        }
    }

    private static readonly Dictionary<Item, char> ItemToSymbol =
        new Dictionary<Item, char>
        {
            { Item.None, '.' },
            { Item.Player, '@' },
            { Item.Seafood, 'S' },
            { Item.Carne, 'C' },
            { Item.Egg, 'E' },
            { Item.Leche, 'L' },
            { Item.Fruit, 'F' },
            { Item.Vegetable, 'V' },
            { Item.Water, 'W' },
            { Item.Mineral, 'M' },
            { Item.Rock, 'R' }
        };

    public static char GetSymbolFromItem(Item item)
    {
        if (ItemToSymbol.TryGetValue(item, out char symbol))
        {
            return symbol;
        }
        else
        {
            throw new KeyNotFoundException($"Item {item} has no symbol associated");
        }
    }

    public static readonly Dictionary<char, Item> SymbolToItem =
        ItemToSymbol.ToDictionary(pair => pair.Value, pair => pair.Key);

    public static Item GetItemFromSymbol(char symbol)
    {
        if (SymbolToItem.TryGetValue(symbol, out Item item))
        {
            return item;
        }
        else
        {
            throw new KeyNotFoundException($"Symbol {symbol} has no item associated");
        }
    }

    public static char[][] GenerateTerrain(TerrainType type)
    {
        if (type == TerrainType.Home)
        {
            return new char[][] {
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "..........................／l、.......................".ToCharArray(),
                "........................（ﾟ､ ｡７......................".ToCharArray(),
                "..........................l、ﾞ~ヽ.....................".ToCharArray(),
                "..........................じしf_, )ノ.................".ToCharArray(),
                "..........................◢■■■■■◣.....................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
            };
        }
        else
        {
            var lines = new char[][] {
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
                "......................................................".ToCharArray(),
            };

            // Populate Terrain
            for (int i = 0; i < lines.Length; i++)
            {
                char[] row = lines[i];

                for (int j = 0; j < row.Length; j++)
                {
                    bool hasItem = Random.Shared.Next(100) < ItemChance;
                    if (!hasItem)
                    {
                        continue;
                    }

                    // pick from the item pool
                    List<Item> itemPool = ItemTypesInTerrain(type);
                    int rand = Random.Shared.Next(itemPool.Count);

                    char itemIcon = GetSymbolFromItem(itemPool[rand]);
                    lines[i][j] = itemIcon;
                }
            }

            return lines;
        }
    }

    public static List<Item> ItemTypesInTerrain(TerrainType type)
    {
        if (type == TerrainType.Home)
        {
            throw new ArgumentException("You're not supposed to call this method for Home");
        }

        return type switch
        {
            TerrainType.River => new List<Item>() { Item.Seafood, Item.Water },
            TerrainType.Timmy_Ranch => new List<Item>() { Item.Carne, Item.Egg, Item.Leche },
            TerrainType.Town_Market => new List<Item>() { Item.Fruit, Item.Vegetable },
            TerrainType.Forest => new List<Item>() { Item.Water, Item.Fruit, Item.Vegetable },
            TerrainType.Mountain_Cave => new List<Item>() { Item.Mineral, Item.Rock, Item.Water },
        };
    }
}

// MAP ASCII DESIGN
// Chest
//  ...............................
//  ............--------............
//  ...........|........|...........
//  ...........|........|...........
//  ...........|........|...........
//  ...............................
//


// Home
/*
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ........................／l、.........................
    ......................（ﾟ､ ｡７........................
    ........................l、ﾞ~ヽ.......................
    ........................じしf_, )ノ...................
    ........................◢■■■■■◣......................
    ...........................*..........................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
    ......................................................
*/