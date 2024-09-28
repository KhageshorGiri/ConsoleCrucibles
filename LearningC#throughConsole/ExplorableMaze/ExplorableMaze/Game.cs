using static System.Console;

namespace ExplorableMaze;

public class Game
{
    public Maze maze;
    public Player player;

    public void StartGame()
    {
        string[,] grid =
        {
            { "=", "=", "=", "=", "=", "=", "=" },
            { "=", " ", "=", " ", " ", " ", "X"},
            { " ", " ", "=", " ", "=", " ", "="},
            { "=", " ", " ", " ", "=", " ", "=" },
            { "=", "=", "=", "=", "=", "=", "=" }
        };

        maze = new Maze(grid);
        player = new Player(0, 2);

        // Run the game loop
        RunGameLoop();

    }

    public void DisplayIntro()
    {
        WriteLine("Welcome to the maze game.");
        WriteLine("\nInstructions");
        WriteLine("> User arrow (->) key control your moves.");
        WriteLine("Try to reach to goal, which looks like this:");
        ForegroundColor = ConsoleColor.Green;
        WriteLine("X");
        ResetColor();
        WriteLine("> Press any key to start.");
        ReadKey(true);
    }

    public void DisplayOutro()
    {
        Clear();
        WriteLine("Yor escaped!");
        WriteLine("Thanks for playing.");
        WriteLine("Press any key to exit...");
        ReadKey(true);
    }


    public void DrawFrame()
    {
        Clear();
        maze.DrawGrid();
        player.DrawPlayer();
    }

    public void HandelPlayerInput()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        ConsoleKey key = keyInfo.Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if(maze.IsPostitionWalkable(player.X, player.Y - 1))
                    player.Y -= 1;
                break;

            case ConsoleKey.DownArrow:
                if (maze.IsPostitionWalkable(player.X, player.Y + 1))
                    player.Y += 1;
                break;

            case ConsoleKey.LeftArrow:
                if (maze.IsPostitionWalkable(player.X - 1, player.Y))
                    player.X -= 1;
                break;

            case ConsoleKey.RightArrow:
                if (maze.IsPostitionWalkable(player.X + 1, player.Y))
                    player.X += 1;
                break;

            default:
                break;
        }
    }
    public void RunGameLoop()
    {
        DisplayIntro();
        while (true)
        {
            // Draw Everything
            DrawFrame();

            // Check the player input form the keybord and move the player
            HandelPlayerInput();

            // Check if the player reach the exist and end the game if so.
            string playerCurrentPosition = maze.GetPlayerCurrentPosition(player.X, player.Y);
            if ("X".Equals(playerCurrentPosition))
                break;

            // Give a console a chance to render.
            Thread.Sleep(20);
        }

        DisplayOutro();

    }
}
