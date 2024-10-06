using System;
using static System.Console;

namespace QuickDrawGame;

internal class Game
{
    public void RunGame()
    {
        WriteLine(GameArt.gameNameArt);
        WriteLine();
        WriteLine("=====================================================");
        WriteLine("Welcome to sudoku puzzle.");

        WriteLine("\nPress any key to start...");
        ReadKey(true);

        WriteLine("\nPress any key to exit...");
        ReadKey(true);
    }

}
