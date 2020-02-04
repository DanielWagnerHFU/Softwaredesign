using System;
using System.Collections.Generic;
using TextAdventureCharacter;

namespace TextAdventureGame
{
    public class TextAdventureFileHandler
    {
        protected List<Character> characters;
        public TextAdventureFileHandler(string filepath)
        {
            //TODO
        }
        public List<Character> GetCharacters()
        {
            return this.characters;
        }
    }
}