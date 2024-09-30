using System;
using static System.Console;

namespace ArtGame;

public class Game
{

    public void RunGame()
    {
        WriteLine("#### === Micro RPG === ####");

        WaitForKey();
    }


    public void WaitForKey()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
    }
}
