using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int key;
        public Key(string name, string description, int key) 
        : base(name, description)
        {
            this.key = key;
        }
        public int GetKey()
        {
            return this.key;
        }
        public override void UseOnCharacter(Character character)
        {
            Console.WriteLine("This item cannot be used on a character");
        }
        public override void UseOnGateway(Gateway gateway)
        {
            gateway.UseItem(this);
        }
        public static Key BuildFromXmlNode(XmlNode itemNode)
        {
            XmlAttributeCollection attributes = itemNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            int key = Int32.Parse(attributes[3].Value);
            return new Key(name, description, key);
        }
    }
}