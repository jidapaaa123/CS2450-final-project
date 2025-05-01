using Persistence;
namespace Logic;

public static class Kitchen
{
    public static readonly Dictionary<Item, Item[]> Recipes = new()
    {
        {Item.Flour, [Item.Vegetable, Item.Vegetable]},
        {Item.Bread, [Item.Flour, Item.Water]},
        {Item.Steak, [Item.Carne]},
        {Item.Fried_Chicken, [Item.Egg, Item.Carne, Item.Flour]},
        {Item.Salt, [Item.Mineral, Item.Rock]},
    };

    public static readonly Item[] FoodList = 
    {
        Item.Steak,
        Item.Fried_Chicken,
    };
}