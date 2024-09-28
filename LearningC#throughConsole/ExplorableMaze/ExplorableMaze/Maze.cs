using System;
using static System.Console;

namespace ExplorableMaze;

public class Maze
{
    private string[,] Grid;
    private int Rows;
    private int Cols;

    public Maze(string[,] grid)
    {
        Grid = grid;
        Rows = grid.GetLength(0);
        Cols = grid.GetLength(1);
    }

    public void DrawGrid()
    {
        for(int y = 0; y < Rows; y++)
        {
            for(int x = 0; x < Cols; x++)
            {
                string elemet = Grid[y, x];
                SetCursorPosition(x, y);
                Write(elemet);
            }
        }
    }

    public bool IsPostitionWalkable(int x, int y)
    {
        // check boundary first
        if(x <= 0 || y <= 0 || x >=Cols || y >= Rows)
            return false;

        return Grid[y, x] == " " || Grid[y, x] == "X";
    }
}
