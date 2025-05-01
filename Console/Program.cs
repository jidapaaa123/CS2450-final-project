using Display;
using Logic;

GameManager manager = new(new Player("You"));
int i = 4;

string footerMessage = "";
while (true)
{
    Console.Clear();
    UI.PrintScreenHeader(manager.Maps[i]);
    UI.PrintMapDisplay(manager.Maps[i]);
    UI.PrintScreenFooter(footerMessage);


    Logic.Action action = UI.GetAction();
    try
    {
        manager.ProcessAction(action);
        footerMessage = "";
    }
    catch (SolidObjectCollisionException e)
    {
        footerMessage = e.Message;
    }
}
