using System;
using static System.Console;

namespace ArtGame;

public class Game
{
    private Ant RedAnt;
    private Bee bee;
    public Game()
    {
        RedAnt = new Ant("Red Ant", 200, ConsoleColor.Red, 3);
        bee = new Bee("Normal Bee", 250, ConsoleColor.DarkYellow, true);
    }

    public void RunGame()
    {
        WriteLine("#### === Micro RPG === ####");

        RedAnt.DisplayInfo();
        RedAnt.Charge();
        RedAnt.Bite();

        WriteLine();


        bee.DisplayInfo();
        bee.Fly();
        bee.Stinc();

        WaitForKey();
    }


    public void WaitForKey()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
    }
}
