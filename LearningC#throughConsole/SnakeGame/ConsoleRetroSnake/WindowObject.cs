
namespace ConsoleRetroSnake;

public class WindowObject
{
    private int x;
    private int y;

    public int X { get { return x; } }
    public int Y { get { return y; } }

    public WindowObject(int xaxis, int yaxis)
    {
        x = xaxis;
        y = yaxis;
    }

}
