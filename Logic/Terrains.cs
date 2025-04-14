namespace Logic;

public enum TerrainType { Home, Forest, River, Mountain_Cave, Timmy_Ranch, Town_Market }

/// <summary>
/// Record of Terrain templates to choose from
/// Returns 2D arrays of the Terrain template
/// Template: Fixed items only, NO portals 
/// </summary>
public static class Terrains
{
    public const int Width = 70;
    public const int Height = 22;

    public static char[][] Home()
    {
        var lines = new char[][] {
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),
            "......................................................................".ToCharArray(),

        };

        return lines;
    }
}

// MAP ASCII DESIGN
// Cat
//  ...............................
//  .............／l、..............
//  ...........（ﾟ､ ｡７.............
//  .............l、ﾞ~ヽ............
//  .............じしf_, )ノ........
//  ............ ◢■■■■■◣..........
//  ...............................
//  ...............................
//  ...............................
//  ...............................
//  ...............................
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