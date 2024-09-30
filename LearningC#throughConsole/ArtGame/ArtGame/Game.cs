using System;
using static System.Console;

namespace ArtGame;

public class Game
{
    private Ant RedAnt;
    public Game()
    {
        RedAnt = new Ant("Red Ant", 200, ConsoleColor.Red, 3);
    }

    public void RunGame()
    {
        WriteLine("#### === Micro RPG === ####");

        RedAnt.DisplayInfo();
        RedAnt.Charge();
        RedAnt.Bite();

        WaitForKey();
    }


    public void WaitForKey()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
    }
}
