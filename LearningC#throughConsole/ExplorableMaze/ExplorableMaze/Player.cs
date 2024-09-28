using System;
using static System.Console;

namespace ExplorableMaze;

public class Player
{
    private int X { get; set; }
    private int Y { get; set; }
    private string PlayerMarker { get; set; }
    private ConsoleColor PlayerColor { get; set; }

    public Player(int initialX,  int initialY)
    {
        X = initialX;
        Y = initialY;
        PlayerMarker = "O";
        PlayerColor = ConsoleColor.Red;
    }

    public void DrawPlayer()
    {
        ForegroundColor = PlayerColor;
        SetCursorPosition(X, Y);
        Write(PlayerMarker);
        ResetColor();
    }
}
