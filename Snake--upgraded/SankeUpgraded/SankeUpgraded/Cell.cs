
using static System.Console;

namespace SankeUpgraded;

public readonly struct Cell
{
    private const char CellChar = '█';

    public int X { get; }
    public int Y { get; }
    public ConsoleColor Color { get; }
    public int CellSize { get; }


    public Cell(int x, int y, ConsoleColor color, int cellSize = 1)
    {
        X = x;
        Y = y;
        Color = color;
        CellSize = cellSize;
    }

    public void Draw()
    {
        ForegroundColor = Color;
        for (int x = 0; x < CellSize; x++)
        {
            for(int y = 0; y < CellSize; y++)
            {
                Console.SetCursorPosition(X * CellSize + x, Y * CellSize + y);
                Console.Write(CellChar);
            }
        }
    }

    public void Clear()
    {
        for (int x = 0; x < CellSize; x++)
        {
            for (int y = 0; y < CellSize; y++)
            {
                Console.SetCursorPosition(X * CellSize + x, Y * CellSize + y);
                Console.Write(' ');
            }
        }
    }
}
