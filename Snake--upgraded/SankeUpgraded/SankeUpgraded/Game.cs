using System;
using static System.Console;

namespace SankeUpgraded;

public class Game
{
    // Building Display Window
    private const int MapWidth = 30;
    private const int MapHeight = 20;

    private const int ScreenWidth = MapWidth * 3;
    private const int ScreenHeight = MapHeight * 3;

    private const ConsoleColor BorderColor = ConsoleColor.Red;

    public void RunGame()
    {
        DisplayIntro();

        DisplayWindow();

        ReadKey(true);

    }

    public void DisplayIntro()
    {
        WriteLine("Welcome");
        ReadKey(true);
    }

    public void DisplayWindow()
    {
        Clear();
        SetWindowSize(ScreenWidth, ScreenHeight);
        SetBufferSize(ScreenWidth, ScreenHeight);

        DrawBoard();

        CursorVisible = false;
    }

    static void DrawBoard()
    {
        for (int i = 0; i < MapWidth; i++)
        {
            new Cell(i, 0, BorderColor).Draw();
            new Cell(i, MapHeight - 1, BorderColor).Draw();
        }

        for (int i = 0; i < MapHeight; i++)
        {
            new Cell(0, i, BorderColor).Draw();
            new Cell(MapWidth - 1, i, BorderColor).Draw();
        }
    }
}
