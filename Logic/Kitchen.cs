using System.Text;
using Persistence;
namespace Logic;

public static class Kitchen
{
    public static readonly Dictionary<Item, Item[]> CraftableRecipes = new()
    {
        {Item.Flour, [Item.Vegetable, Item.Vegetable]},
        {Item.Bread, [Item.Flour, Item.Water]},
        {Item.Steak, [Item.Carne]},
        {Item.Fried_Chicken, [Item.Egg, Item.Carne, Item.Flour]},
        {Item.Salt, [Item.Mineral, Item.Rock]},
        {Item.Steak_Sandwich, [Item.Bread, Item.Steak, Item.Salt]},
        {Item.Crispy_Chicken_Sandwich, [Item.Bread, Item.Fried_Chicken, Item.Salt]},
        {Item.Waffle, [Item.Flour, Item.Egg, Item.Leche, Item.Sugar]},
        {Item.Cornbread, [Item.Vegetable, Item.Flour, Item.Egg, Item.Leche, Item.Sugar]},
        {Item.Pancake, [Item.Flour, Item.Egg, Item.Leche, Item.Sugar]},
        {Item.Sashimi, [Item.Seafood, Item.Salt]},
        {Item.Fried_Fish, [Item.Seafood, Item.Egg, Item.Flour, Item.Salt]},
        {Item.Noodles, [Item.Flour, Item.Egg]},
        {Item.Garfield_Spaghetti, [Item.Noodles, Item.Carne, Item.Vegetable]},
        {Item.Raw_Egg_Water, [Item.Water, Item.Carne, Item.Egg, Item.Egg, Item.Egg, Item.Egg, 
                          Item.Egg, Item.Egg, Item.Egg, Item.Egg, Item.Egg, 
                          Item.Egg, Item.Egg, Item.Egg]}
    };

    public static readonly Item[] AllCraftables = CraftableRecipes.Keys.ToArray();

    public static readonly Item[] EdibleFoodList =
    {
        Item.Bread, Item.Steak, Item.Fried_Chicken,
        Item.Steak_Sandwich, Item.Crispy_Chicken_Sandwich, 
        Item.Waffle, Item.Cornbread, Item.Pancake,
        Item.Sashimi, Item.Fried_Fish, Item.Noodles, Item.Garfield_Spaghetti,
        Item.Raw_Egg_Water
    };
}