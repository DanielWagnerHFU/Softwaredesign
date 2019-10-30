using System;

namespace A03_OXO
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey choice;
            do
            {
            choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("1. Choice");
                        break;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("2. Choice");
                        break;
                }
            } while (choice != ConsoleKey.D1 && choice != ConsoleKey.D2);
        }
    }
}
