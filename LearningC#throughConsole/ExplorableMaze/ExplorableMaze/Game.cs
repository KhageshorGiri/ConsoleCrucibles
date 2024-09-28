using static System.Console;

namespace ExplorableMaze;

public class Game
{
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

        Maze maze = new Maze(grid);
        maze.DrawGrid();

        Player player = new Player(0, 2);
        player.DrawPlayer();

        ReadKey(true);
    }
}
