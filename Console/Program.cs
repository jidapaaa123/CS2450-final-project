using Display;
using Logic;

GameManager manager = new(new Player("You"));
int i = 4;

while (true)
{
    Console.Clear();
    UI.PrintScreenHeader(manager.Maps[i]);
    UI.PrintMapDisplay(manager.Maps[i]);
    
    Logic.Action action = UI.GetAction();
    manager.ProcessAction(action);
}
