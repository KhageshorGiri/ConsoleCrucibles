using static System.Console;

namespace ConsoleRetroSnake;

public class Game
{

    WindowObject grid ;
    WindowObject snake ;
    WindowObject food ;
    bool play = true;

    public Game()
    {
         grid = new WindowObject(30, 20);
         snake = new WindowObject(10, 10);
         food = new WindowObject(20, 5);

    }

    public void RunGame()
    {
        DisplayIntro();

        while (play)
        {

            DisplayWindow();

            //if (CollisonDetectionWithWall(snake.X, snake.Y))
            //    AskUserToPlayAgain();

            CollisonDetectionWithFood(snake.X, snake.Y);
            HandelPlayerInput();

            Thread.Sleep(20);
        }

        DisplayOutro();

    }

    public void AskUserToPlayAgain()
    {
        Write("\nDo you want to play again?[Y/N]: ");
        var userChoice = ReadLine()?.Trim().ToLower();
        if(userChoice == "yes" || userChoice == "y")
            play = true;
        play = false;
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

    public bool CollisonDetectionWithWall(int x , int y)
    {
        if(x == 15 || y == 15)
            return true;
        return false;
    }

    public void CollisonDetectionWithFood(int x, int y)
    {
        if (x == food.X && y == food.Y)
            WriteLine("Food Found");
    }
    public void HandelPlayerInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        ConsoleKey key = keyInfo.Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if(IsLocationMoveable(snake.X, snake.Y))
                    snake.UpdateYCoordinate(snake.Y - 1);
                   
                break;

            case ConsoleKey.DownArrow:
                if (IsLocationMoveable(snake.X, snake.Y+1))
                    snake.UpdateYCoordinate(snake.Y + 1);
               
                break;

            case ConsoleKey.LeftArrow:
                if (IsLocationMoveable(snake.X, snake.Y))
                    snake.UpdateXCooridnate(snake.X - 1);
                break;

            case ConsoleKey.RightArrow:
                if (IsLocationMoveable(snake.X+1, snake.Y))
                    snake.UpdateXCooridnate(snake.X + 1);
                break;

            default:
                break;
        }
    }

    public bool IsLocationMoveable(int x, int y)
    {
        if(x > 0 && y > 0 && x < grid.X && y < grid.Y)
            return true;
        return false;
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
