namespace Logic;

public class GameManager
{
    const int mapsAmount = 9;
    const int width = 30;
    const int height= 30;

    List<int[,]> Maps = new List<int[,]>();

    public GameManager()
    {
        // For each of the 9 maps, initialize arrays in Maps List
        for (int i = 0; i < mapsAmount; i++)
        {
            Maps[i] = new int[height, width];
        }


    }

}
// <int[size.width, size.height]>