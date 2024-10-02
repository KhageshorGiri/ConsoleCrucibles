
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

    public void UpdateXCooridnate(int x_new)
    {
        x = x_new;
    }

    public void UpdateYCoordinate(int y_new)
    {
        y = y_new; 
    }

    public void UpdateCoordinate(int x_new , int y_new)
    {
        x = x_new;
        y = y_new;
    }
   
}
