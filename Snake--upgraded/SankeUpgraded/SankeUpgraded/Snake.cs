using SankeUpgraded.Enums;

namespace SankeUpgraded;

/// <summary>
/// Class that helps to create object for snake with its propertis and behaviors
/// </summary>
public class Snake
{
    private readonly ConsoleColor HeadColor;
    private readonly ConsoleColor BodyColor;

    public Cell Head {  get; private set; }
    public Queue<Cell> Body { get; } = new Queue<Cell>();
  
    public Snake(int initialX, int initialY, 
        ConsoleColor headColor, ConsoleColor bodyColor, 
        int bodyLenght = 3)
    {
        HeadColor = headColor;
        BodyColor = bodyColor;

        Head = new Cell(initialX, initialY, headColor);

        for( int i = bodyLenght; i > 0; i--)
        {
            Body.Enqueue(new Cell(Head.X - i - 1, initialY, bodyColor));
        }

        Draw();
    }

    public void Move(Direction direction, bool eat = false)
    {

        Clear();

        Body.Enqueue(new Cell(Head.X, Head.Y, BodyColor));
        if (!eat)
            Body.Dequeue();

        Head = direction switch
        {
            Direction.Right => new Cell(Head.X + 1, Head.Y, HeadColor),
            Direction.Left => new Cell(Head.X - 1, Head.Y, HeadColor),
            Direction.Up => new Cell(Head.X, Head.Y - 1, HeadColor),
            Direction.Down => new Cell(Head.X, Head.Y + 1, HeadColor),
            _ => Head
        };

        Draw();
    }

    public void Draw()
    {
        Head.Draw();

        foreach (Cell cell in Body)
        {
            cell.Draw();
        }
    }

    public void Clear()
    {
        Head.Clear();

        foreach(Cell cell in Body)
        {
            cell.Clear();
        }
    }
}
