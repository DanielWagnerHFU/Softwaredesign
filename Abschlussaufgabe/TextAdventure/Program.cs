using System;
using TextAdventureCharacter;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game is starting...");
            // TODO: execute Game
            string a = "kill";
            if(a.TrimStart("kill") == ""){
                Console.WriteLine("YOOO");
            }
            System.Threading.Thread.Sleep(10000);
        }
    }
}
