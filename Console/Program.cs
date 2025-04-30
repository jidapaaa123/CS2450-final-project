using Display;
using Logic;

GameManager manager = new(new Player("You"));
int i = 0;
UI.PrintScreenHeader(manager.Maps[i]);
UI.PrintMapDisplay(manager.Maps[i]);
