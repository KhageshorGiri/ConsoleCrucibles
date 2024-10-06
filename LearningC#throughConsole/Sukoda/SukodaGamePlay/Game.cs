
using static System.Console;

namespace SudokuGamePlay;

public class Game
{
    public void RunGame()
    {
        WriteLine(AsciiGameName.sudokuGameArt);
        WriteLine();
        WriteLine("=====================================================");
        WriteLine("Welcome to sudoku puzzle.");

        WriteLine("Press any key to exit...");
        ReadKey(true);
    }
}
