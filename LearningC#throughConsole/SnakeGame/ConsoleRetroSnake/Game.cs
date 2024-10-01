using static System.Console;

namespace ConsoleRetroSnake;

public class Game
{

    WindowObject grid ;
    WindowObject snake ;
    WindowObject food ;

    public Game()
    {
         grid = new WindowObject(60, 20);
         snake = new WindowObject(40, 10);
         food = new WindowObject(20, 5);

    }

    public void RunGame()
    {
        DisplayIntro();


        while (true)
        {

            DisplayWindow();

            HandelPlayerInput();

            Thread.Sleep(20);
        }

        DisplayOutro();

    }


    public void DisplayWindow()
    {
        Clear();

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

        SetCursorPosition(snake.X+1, snake.Y);
    }

    public void HandelPlayerInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        ConsoleKey key = keyInfo.Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                break;
            case ConsoleKey.DownArrow:
                break;
            case ConsoleKey.LeftArrow:
                break;
            case ConsoleKey.RightArrow:
                break;
            default:
                break;
        }
    }

    public void DisplayIntro()
    {
        WriteLine("!!! Welcome TO Console Snake Game !!!");
        WriteLine("=========================================");
        WriteLine("\nPress any key to start the game");
        ReadKey(true);
    }


    public void DisplayOutro()
    {
        Clear();
        WriteLine("Thanks for playing game.");
        WriteLine("\nPress any key to exist...");
        ReadKey(true);
    }
  
}
