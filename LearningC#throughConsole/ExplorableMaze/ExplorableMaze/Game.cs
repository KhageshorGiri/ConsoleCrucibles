using static System.Console;

namespace ExplorableMaze;

public class Game
{
    public Maze maze;
    public Player player;

    public void StartGame()
    {
        string[,] grid = LevelParser.ParseFileToArray("../../../Level1.txt");

       /* string[,] grid =
        {
            { "=", "=", "=", "=", "=", "=", "=" },
            { "=", " ", "=", " ", " ", " ", "X"},
            { " ", " ", "=", " ", "=", " ", "="},
            { "=", " ", " ", " ", "=", " ", "=" },
            { "=", "=", "=", "=", "=", "=", "=" }
        };*/

        maze = new Maze(grid);
        player = new Player(2, 1);

        // Run the game loop
        RunGameLoop();

    }

    public void DisplayIntro()
    {

        string gameWelcomeString = @"
=================================================================================================
 __      __       .__                                   
/  \    /  \ ____ |  |   ____  ____   _____   ____   
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \   
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >   
       \/       \/          \/            \/     \/      


___________      ___________.__                _____                           ________                       
\__    ___/___   \__    ___/|  |__   ____     /     \ _____  ________ ____    /  _____/_____    _____   ____  
  |    | /  _ \    |    |   |  |  \_/ __ \   /  \ /  \\__  \ \___   // __ \  /   \  ___\__  \  /     \_/ __ \ 
  |    |(  <_> )   |    |   |   Y  \  ___/  /    Y    \/ __ \_/    /\  ___/  \    \_\  \/ __ \|  Y Y  \  ___/ 
  |____| \____/    |____|   |___|  /\___  > \____|__  (____  /_____ \\___  >  \______  (____  /__|_|  /\___  >
                                 \/     \/          \/     \/      \/    \/          \/     \/      \/     \/ 

===============================================================================================================
";

        WriteLine(gameWelcomeString);
        WriteLine("\nInstructions");
        WriteLine("> User arrow (->) key control your moves.");
        Write("\nTry to reach to goal, which looks like this: ");
        ForegroundColor = ConsoleColor.Green;
        Write("X");
        ResetColor();
        WriteLine("\n> Press any key to start.");
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
