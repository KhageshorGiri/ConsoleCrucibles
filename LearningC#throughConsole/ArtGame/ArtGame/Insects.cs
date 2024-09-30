using static System.Console;

namespace ArtGame;

public class Insects
{
    protected string Name;
    protected int Health;
    protected string TextArt;
    protected ConsoleColor Color;

    public Insects(string name, int health, string textArt, ConsoleColor color)
    {
        Name = name;
        Health = health;
        TextArt = textArt;
        Color = color;
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

}
