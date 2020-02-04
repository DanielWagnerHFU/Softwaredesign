using System;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public sealed class TextAdventureGame
    {
        private List<Character> characters;
        public TextAdventureGame(string filepath)
        {
            TextAdventureFileHandler fileHandler = new TextAdventureFileHandler(filepath);
            this.characters = fileHandler.GetCharacters();
        }
        public TextAdventureGame(List<Character> characters)
        {
            //testconstructor
            this.characters = characters;
        }
    }
}