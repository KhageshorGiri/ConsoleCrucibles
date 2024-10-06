using static System.Console;

namespace ConsoleRetroSnake;

public class Game
{

    WindowObject grid ;
    WindowObject snake ;
    WindowObject food ;
    bool play = true;
    int score = 0;
    Random rand = new Random();

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

            HandelPlayerInput();

            Thread.Sleep(20);
        }

       
    }

    public void AskUserToPlayAgain()
    {
        Write("\nDo you want to play again?[Y/N]: ");
        var userChoice = ReadLine()?.Trim().ToLower();
        if(userChoice == "yes" || userChoice == "y")
        {
            play = true;
            RunGame();
        }
        play = false;
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
                if (WallCollisionDetection(snake.X, snake.Y))
                    AskUserToPlayAgain();
                else if (!ObjectCollessionDetection(snake.X, snake.Y))
                    snake.UpdateYCoordinate(snake.Y - 1);
                break;

            case ConsoleKey.DownArrow:
                if (WallCollisionDetection(snake.X, snake.Y+1))
                    AskUserToPlayAgain();
                else if (!ObjectCollessionDetection(snake.X, snake.Y+1))
                    snake.UpdateYCoordinate(snake.Y + 1);
                break;

            case ConsoleKey.LeftArrow:
                if (WallCollisionDetection(snake.X, snake.Y))
                    AskUserToPlayAgain();
                else if (!ObjectCollessionDetection(snake.X, snake.Y))
                    snake.UpdateXCooridnate(snake.X - 1);
                break;

            case ConsoleKey.RightArrow:
                if (WallCollisionDetection(snake.X+1, snake.Y))
                    AskUserToPlayAgain();
                else if (!ObjectCollessionDetection(snake.X+1, snake.Y))
                    snake.UpdateXCooridnate(snake.X + 1);
                break;

            default:
                break;
        }
    }


    // This is the function that handel collession detection with food
    public bool ObjectCollessionDetection(int x, int y)
    {
        // logic to find food collision detection
        if (x == food.X && y == food.Y)
        {
            score += 1;

            // set food position randomly
            int food_x = rand.Next(5, 25);
            int food_y = rand.Next(5, 15);
            food.UpdateCoordinate(food_x, food_y);
            return true;
        }

        return false;
    }

    public bool WallCollisionDetection(int x, int y)
    {
        if (x > 0 && y > 0 && x < grid.X && y < grid.Y)
            return false;
        return true;
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
        WriteLine($"Final Score : {score}");
        WriteLine("Thanks for playing game.");
        WriteLine("\nPress any key to exist...");
        ReadKey(true);
    }
  
}
