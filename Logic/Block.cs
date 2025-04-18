namespace Logic;

public class Block
{
    private readonly string solidIcon;
    public bool IsSolid = false;
    public Item Item = Item.None;
    public string Icon {
        get
        {
            if (!IsSolid)
            {
                return Terrains.ItemToString(Item);
            }
            else
            {

            }
        }
    }

    public Block(Item item, bool IsSolid)
    {
        Item = item;
    }
}