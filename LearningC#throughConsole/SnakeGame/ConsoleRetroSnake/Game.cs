using static System.Console;

namespace ConsoleRetroSnake;

public class Game
{

    public Game()
    {

    }

    public void RunGame()
    {
        DisplayIntro();

        DisplayWindow();

        WaitForKeyPress();
    }


    public void DisplayWindow()
    {
        //Clear();
        var grid = new WindowObject(50, 50);

        for(int y = 0; y< grid.Y; y++)
        {
            Write("#");
        }
    }

    public void DisplayIntro()
    {
        WriteLine("!!! Welcome TO Console Snake Game !!!");
        WriteLine("=========================================");
    }

    public void WaitForKeyPress()
    {
        WriteLine("\nPress any key to exist...");
        ReadKey(true);
    }
}
