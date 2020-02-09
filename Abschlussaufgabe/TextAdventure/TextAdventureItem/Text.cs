using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Text : Item
    {
        private string _text;
        public Text(string name, string description, string text) 
        : base(name, description)
        {
            this._text = text;
        }
        public override void UseOnCharacter(Character character, Character user)
        {
            if(CharacterIsPlayer(character) && CharacterIsPlayer(user))
            {
                Console.WriteLine(this._text);
            }
        }
        public override void UseOnGateway(Gateway gateway, Character user)
        {
            if(CharacterIsPlayer(user))
            {
                Console.WriteLine("You cannot use the item on this gateway");
            }            
        }
        public static Text BuildFromXmlNode(XmlNode itemNode)
        {
            XmlAttributeCollection attributes = itemNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            string text = attributes[3].Value;
            return new Text(name, description, text);
        }
    }
}