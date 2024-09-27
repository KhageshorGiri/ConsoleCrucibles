using System;
using static System.Console;

namespace ExplorableMaze;

public class Game
{
    public void StartGame()
    {
        WriteLine("Game is starting.");

        WriteLine("\n\nPress any key to exit...");
        ReadKey(true);
    }
}
