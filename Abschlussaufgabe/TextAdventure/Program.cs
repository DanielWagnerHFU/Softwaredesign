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
            Area area = new Area(0, "area", "You are in a endless space.");
            Area area1 = new Area(0, "area1", "You are in a spaceship");
            Gateway gateway = new Gateway(0, area, area1);
            PlayerCharacter player = new PlayerCharacter(0,"player","test",area);
            NonPlayerCharacter npc = new NonPlayerCharacter(1,"npc","A old npc",area);
            Key key = new Key(0,1,"key","A old Key");
            player.AddItem(key);
            List<Character> characters = new List<Character>();
            characters.Add(player);
            characters.Add(npc);
            TextAdventureGame.TextAdventureGame game = new TextAdventureGame.TextAdventureGame(characters);
            game.StartGameLoop();
        }
    }
}
