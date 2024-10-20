using SankeUpgraded.Enums;
using System;
using System.Diagnostics;
using static System.Console;
using static System.Formats.Asn1.AsnWriter;

namespace SankeUpgraded;

public class Game
{
    // Building Display Window
    private const int MapWidth = 30;
    private const int MapHeight = 20;

    private const int ScreenWidth = MapWidth * 3;
    private const int ScreenHeight = MapHeight * 3;

    private const int FrameMilliseconds = 200;

    private const ConsoleColor BorderColor = ConsoleColor.Gray;

    private const ConsoleColor FoodColor = ConsoleColor.Green;

    private const ConsoleColor HeadColor = ConsoleColor.DarkCyan;
    private const ConsoleColor BodyColor = ConsoleColor.Red;

    public static readonly Random rand = new Random();

    public void RunGame()
    {
        SetWindowSize(ScreenWidth, ScreenHeight);
        SetBufferSize(ScreenWidth, ScreenHeight);
        CursorVisible = false;

        while (true)
        {
            StartGame();
            Thread.Sleep(5000);
            ReadKey(true);
        }
    }


    static void StartGame()
    {
        int score = 0;

        Clear();
        DrawBoard();

        Snake snake = new Snake(10, 6, HeadColor, BodyColor);

        Cell food = GenerateFood(snake);
        food.Draw();

        Direction currentMovement = Direction.Right;

        int lagMs = 0;
        var sw = new Stopwatch();

        while (true)
        {
            sw.Restart();
            Direction oldMovement = currentMovement;

            while (sw.ElapsedMilliseconds <= FrameMilliseconds - lagMs)
            {
                if (currentMovement == oldMovement)
                    currentMovement = ReadMovement(currentMovement);
            }

            sw.Restart();

            if (snake.Head.X == food.X && snake.Head.Y == food.Y)
            {
                snake.Move(currentMovement, true);
                food = GenerateFood(snake);
                food.Draw();

                score++;

                Task.Run(() => Beep(1200, 200));
            }
            else
            {
                snake.Move(currentMovement);
            }

            if (snake.Head.X == MapWidth - 1
                || snake.Head.X == 0
                || snake.Head.Y == MapHeight - 1
                || snake.Head.Y == 0
                || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                break;

            lagMs = (int)sw.ElapsedMilliseconds;
        }

        snake.Clear();
        food.Clear();

        SetCursorPosition(ScreenWidth / 3, ScreenHeight / 2);
        WriteLine($"Game over, Score: {score}");

        Task.Run(() => Beep(200, 600));
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

    static Cell GenerateFood(Snake snake)
    {
        Cell food;
        do
        {
            food = new Cell(rand.Next(1, MapWidth - 2), rand.Next(1, MapHeight - 2), FoodColor);
        } while (
            snake.Head.X == food.X && snake.Head.Y == food.Y ||
            snake.Body.Any(b => b.X == food.X && b.Y == food.Y)
        );

        return food;
    }

    static Direction ReadMovement(Direction currentDirection)
    {
        if (!KeyAvailable)
            return currentDirection;

        ConsoleKey key = ReadKey(true).Key;

        currentDirection = key switch
        {
            ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
            ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
            ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
            ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
            _ => currentDirection
        };

        return currentDirection;
    }
}
