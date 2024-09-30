using static System.Console;

namespace ArtGame;

public class Bee : Insects
{
    private bool HasPoision;
    public Bee(string name, int health,  ConsoleColor color, bool hasPoision) 
        : base(name, health, ArtAssest.Bee, color)
    {
        HasPoision = hasPoision;
    }

    public void Fly()
    {
        BackgroundColor = Color;
        Write($" {Name}\t");
        ResetColor();
        WriteLine("Can Fly in air.");
    }

    public void Stinc()
    {
        BackgroundColor = Color;
        Write($" {Name}\t");
        ResetColor();
        if (HasPoision)
            WriteLine("It has posion.");
        else
            WriteLine("It doesnot have any posion");
    }
}
