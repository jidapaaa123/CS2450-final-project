using Display;
using Logic;

GameManager manager = new(new Player("You"));

Console.WriteLine(UI.DisplayOfMap(manager.Maps[0]));

// throw new Exception("make a new Map class? So list of Maps instead of cha[][]?");

// Console.Write('🍏');