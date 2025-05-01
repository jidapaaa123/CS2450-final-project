using Persistence;


namespace Logic;

public class GameManager
{
    const int mapsAmount = 9;

    public List<Map> Maps = new();

    public int CurrentMapIndex;
    public Player Player;
    public Item RequestedFood;

    public GameManager(Player player)
    {
        Player = player;
        CurrentMapIndex = 4; // index of Home

        // For each of the 9 maps, initialize in Maps List
        // Plop the player at starting place: Home (0,0)
        for (int i = 0; i < 4; i++)
        {
            Maps.Add(new Map(i, (null, null)));
        }
        Maps.Add(new Map(4, (0, 0)));
        for (int i = 5; i < mapsAmount; i++)
        {
            Maps.Add(new Map(i, (null, null)));
        }

        loadData();
    }

    private void loadData()
    {
        (RequestedFood, Player.Inventory) = DataManager.LoadData();
    }

    public void ProcessMovement(Action movement)
    {
        if (!Player.ActionIsMovement(movement))
        {
            throw new ArgumentException("ProcessMovement(): Action not movement");
        }


        //  TO-DO: handle map switches / boundary collisions
        if (!Maps[CurrentMapIndex].CanMakeTheMove(movement, out int mapIndex, out int rowChange, out int colChange))
        {
            throw new SolidObjectCollisionException("Movement into solid object not allowed");
        }

        Item collectedItem;
        // detect map changes
        if (mapIndex != CurrentMapIndex)
        {
            (int?, int?) currentCoordinate = Maps[CurrentMapIndex].PlayerPosition;

            // Player is no longer in old map:
            Maps[CurrentMapIndex].PlayerLeavesMap();

            // Player is in new map:
            CurrentMapIndex = mapIndex;
            Maps[CurrentMapIndex].PlayerEntersMap(currentCoordinate, movement, out collectedItem);
        }
        else
        {
            Maps[CurrentMapIndex].MoveWithinMap(rowChange, colChange, out collectedItem);
        }

        Player.CollectItem(collectedItem);
    }

    public bool Feed()
    {
        if (!Player.Inventory.Contains(RequestedFood))
        {
            return false;
        }

        Player.Inventory.Remove(RequestedFood);

        // Generate a new request
        int rand = Random.Shared.Next(Kitchen.EdibleFoodList.Length);
        RequestedFood = Kitchen.EdibleFoodList[rand];

        return true;
    }

}
