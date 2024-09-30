using static System.Console;

namespace ArtGame;

public class Ant : Insects
{
    private double ChargeDistance;

    public Ant( string name, int health, ConsoleColor color, double chargeDistance)
        : base(name, 200, ArtAssest.Ant, color)
    {
        ChargeDistance = chargeDistance;
    }

    public void Charge()
    {
        BackgroundColor = Color;
        Write($"{Name}\t");
        ResetColor();
        WriteLine($"Charge is {Charge}");
    }

    public void Bite()
    {
        BackgroundColor = Color;
        Write($"{Name}\t");
        ResetColor();
        WriteLine($"Bites");
    }

}
