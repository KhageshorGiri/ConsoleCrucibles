using static System.Console;

namespace ArtGame;

public class Ant
{
    private string Name;
    private int Health;
    private string TextArt;
    private ConsoleColor Color;
    private double ChargeDistance;

    public Ant( string name, int health, ConsoleColor color, double chargeDistance)
    {
        Name = name;
        Health = health;    
        Color = color;
        TextArt = ArtAssest.Ant;
        ChargeDistance = chargeDistance;
    }

    public void DisplayInfo()
    {
        ForegroundColor = Color;
        WriteLine($"--- {Name} ---");
        WriteLine($"\n{TextArt}\n");
        WriteLine($"Health : {Health}");
        WriteLine($"------");
        ResetColor();
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
