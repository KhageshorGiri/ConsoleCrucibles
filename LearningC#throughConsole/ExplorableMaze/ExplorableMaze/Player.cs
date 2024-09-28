using System;
using static System.Console;

namespace ExplorableMaze;

public class Player
{
    public int X { get; set; }
    public int Y { get; set; }
    public string PlayerMarker { get; set; }
    public ConsoleColor PlayerColor { get; set; }

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
