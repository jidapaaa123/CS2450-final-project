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
    catch (Exception ex)
    {
        if (ex is SolidObjectCollisionException || ex is CannotFeedCatException || ex is HappyCatException)
        {
            footerMessage = ex.Message;
        }
        else
        {
            throw;
        }
    }

}
