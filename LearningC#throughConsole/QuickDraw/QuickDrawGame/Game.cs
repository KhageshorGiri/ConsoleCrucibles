using System;
using System.Diagnostics;
using static System.Console;

namespace QuickDrawGame;

public class Game
{
    public Game()
    {
        
    }

    public void RunGame()
    {
        DisplayIntro();
        GamePlay();
    }

    public void GamePlay()
    {
        while (true)
        {
            DisplayMenu();

            TimeSpan? requiredReactionTime = null;

            while(requiredReactionTime is null)
            {
                CursorVisible = false;

                ConsoleKeyInfo keyInfo = ReadKey();
                ConsoleKey key = keyInfo.Key;

                switch (key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1: requiredReactionTime = TimeSpan.FromMilliseconds(1000); break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2: requiredReactionTime = TimeSpan.FromMilliseconds(0500); break;
                    case ConsoleKey.D3 or ConsoleKey.NumPad3: requiredReactionTime = TimeSpan.FromMilliseconds(0250); break;
                    case ConsoleKey.D4 or ConsoleKey.NumPad4: requiredReactionTime = TimeSpan.FromMilliseconds(0125); break;
                    case ConsoleKey.Escape: break;
                }
            }

            Clear();

            // this is signel form computer
            TimeSpan signal = TimeSpan.FromMilliseconds(Random.Shared.Next(5000, 25000));
            WriteLine(GameArt.wait);

            // Add stopwatch
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart();
            bool toFast = false;

            while(stopwatch.Elapsed < signal && !toFast)
            {
                if(KeyAvailable && ReadKey(true).Key is ConsoleKey.Spacebar)
                    toFast = true;
            }

            Clear();
            CursorVisible = false;

            WriteLine(GameArt.fire);
            stopwatch.Restart();

            bool toSlow = true;
            TimeSpan reactionTime = default;
            while(!toFast && stopwatch.Elapsed < requiredReactionTime && toSlow)
            {
                if(KeyAvailable && ReadKey(true).Key is ConsoleKey.Spacebar)
                {
                    toSlow = false;
                    reactionTime = stopwatch.Elapsed;
                }    
            }

            Clear();
            WriteLine(
                toFast ? GameArt.loseTooFast :
                toSlow ? GameArt.loseTooSlow : $"{GameArt.win}{Environment.NewLine} Reaction Time : {reactionTime.TotalMilliseconds} milliseconds.");

            WriteLine("Do you want to play again?\n Play again [enter] or quit [Esc]");
            CursorVisible = false;

            // Define a label
        GetEnterOrSpace:
            switch (ReadKey(true).Key)
            {
                case ConsoleKey.Enter: break;
                case ConsoleKey.Spacebar: return;
                default: goto GetEnterOrSpace;
            }

            ReadKey(true);
        }
    }

    public void DisplayIntro()
    {
        WriteLine(GameArt.gameNameArt);
        WriteLine();
        WriteLine("=====================================================");
        WriteLine("Welcome to sudoku puzzle.");

        WriteLine("\nPress any key to start...");
        ReadKey(true);

    }

    public void DisplayMenu()
    {
        Clear();
        WriteLine(GameArt.menu);
    }

}
