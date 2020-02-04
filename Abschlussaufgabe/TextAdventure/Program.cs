using System;
using TextAdventureCharacter;
using TextAdventureGame;
using TextAdventureItem;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Area area = new Area(0, "area", "a endless space");
            PlayerCharacter player = new PlayerCharacter(0,"player","test",area);
            List<Character> characters = new List<Character>();
            characters.Add(player);
            TextAdventureGame.TextAdventureGame game = new TextAdventureGame.TextAdventureGame(characters);
            game.StartGameLoop();
            Console.WriteLine("____TERMINATED____");
            System.Threading.Thread.Sleep(100000);
        }
    }
}
