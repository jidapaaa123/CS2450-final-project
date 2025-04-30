using Display;
using Logic;

GameManager manager = new(new Player("You"));
int i = 4;

List<string> footerMessages = new();
while (true)
{
    Console.Clear();
    UI.PrintScreenHeader(manager.Maps[i]);
    UI.PrintMapDisplay(manager.Maps[i]);
    UI.PrintScreenFooter(footerMessages);


    Logic.Action action = UI.GetAction();
    try
    {
        manager.ProcessAction(action);
    }
    catch (SolidObjectCollisionException)
    {
        
    }
}
