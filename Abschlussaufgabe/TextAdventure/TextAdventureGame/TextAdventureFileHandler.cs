using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using System.Xml;

namespace TextAdventureGame
{
    public class TextAdventureFileHandler
    {
        protected List<Character> characters;
        protected XmlNodeList textAdventureNodeList;
        public TextAdventureFileHandler(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            textAdventureNodeList = xmlDocument.SelectNodes("/TextAdventureGame");
        }
        public List<Character> GetCharacters()
        {
            return this.characters;
        }
    }
}