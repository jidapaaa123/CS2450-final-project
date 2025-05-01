using Display;
using Logic;

GameManager manager = new(new Player("You"));

string footerMessage = "";
while (true)
{
    Console.Clear();
    UI.PrintScreenHeader(manager);
    UI.PrintMapDisplay(manager.Maps[manager.CurrentMapIndex]);
    UI.PrintScreenFooter(footerMessage);


    Logic.Action action = UI.GetAction();
    try
    {
        UI.ProcessAction(action, manager);
        footerMessage = "";
    }
    catch (SolidObjectCollisionException e)
    {
        footerMessage = e.Message;
    }
}
