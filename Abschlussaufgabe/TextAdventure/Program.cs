using System;
using TextAdventureCharacter;
using TextAdventureGame;
using TextAdventureItem;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventure
{
    static class Program
    {
        static void Main(string[] args)
        {
            TextAdventureMenu menu = new TextAdventureMenu();
            menu.StartMenuLoop();
        }
    }
}
