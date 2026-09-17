using System;
using System.IO.Pipelines;
using System.Runtime.InteropServices;
using System.Text;

class Program
{

    private static char GetRandomLetter()
    {
        Random random = new();

        int number = random.Next(1, 100);
        char result = (char)(number);
        return result;
    }

    public static void Main(string[] args)
    {

        Console.CursorVisible = false;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;

        bool reverse = false;
        bool reversed = false;
        bool doText = true;
        bool doCoolThing = true;

        float delay = 0.55f;

        int coolAmount = 15;
        int d = (int)Math.Round(delay * 100);

        string prevFrame = "";
        string frontText = "";
        string animation = "Hello and welcome! :3";
        string[] frames = animation.Split(";");

        if (doText)
        {
            frames = new string[animation.Length];

            for (int i = 0; i < animation.Length; i++)
            {
                frames[i] = animation[i].ToString();
            }
        }

        int frame = 0;
        int maxFrame = frames.Length;

        while (true)
        {
            Thread.Sleep(d);
            Console.Clear();

            if (frame < 0)
            {
                reversed = true;
                frame = 0;
            }

            if (frame != 0 && doCoolThing)
            {
                for (int i = 0; i <= coolAmount; i++)
                {
                    Thread.Sleep(d / 10);
                    Console.Clear();
                    Console.Write($"{prevFrame}");
                    Console.WriteLine(GetRandomLetter());
                }
            }
            else
            {
                if (doCoolThing)
                {
                    for (int i = 0; i <= coolAmount; i++)
                    {
                        Thread.Sleep(d / 10);
                        Console.Clear();
                        Console.WriteLine(GetRandomLetter());
                    }
                }
            }

            Console.Clear();
            Console.Write($"{prevFrame}{frontText}{frames[frame]}");
            prevFrame = $"{prevFrame}{frontText}{frames[frame]}";
            frame++;

            if (frame == maxFrame && !reverse)
            {
                Thread.Sleep(1000);
                frame = 0;
                Console.Clear();
                prevFrame = "";
            }
            else if ((frame == maxFrame && reverse) || (!reversed && reverse))
            {
                reversed = false;
                frame--;
                frame--;
            }

        }

    }
}