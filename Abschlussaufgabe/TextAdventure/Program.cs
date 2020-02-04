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
            PlayerCharacter player = new PlayerCharacter(0,"player","test",area);
            StaticNonPlayerCharacter npc = new StaticNonPlayerCharacter(1,"npc","A old npc",area,null);
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
