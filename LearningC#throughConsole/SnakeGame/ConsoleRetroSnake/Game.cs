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
        var grid = new WindowObject(60, 20);
        var snake = new WindowObject(40, 10);
        var food = new WindowObject(20, 5);
       
        // here y : cols and x : rows
        for(int y = 0; y< grid.Y; y++)
        {
            for (int x = 0; x < grid.X; x++)
            {
                if(x == snake.X && y == snake.Y)
                {
                    ForegroundColor = ConsoleColor.Green;
                    Write("■");
                    ResetColor();
                }
                else if(x == food.X && y == food.Y)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                    Write("*");
                    ResetColor();
                }
                else if( y == 0 || x == 0 || y == grid.Y-1 || x == grid.X-1)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Write("#");
                    ResetColor();
                }
                else
                {
                    Write(" ");
                }
            }
            WriteLine();
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
