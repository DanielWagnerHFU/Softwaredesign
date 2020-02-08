using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int key;
        public Key(int uniqueIdentificationNumber, string name, string description, int key) : base(uniqueIdentificationNumber, name, description){
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
            int uin = Int32.Parse(attributes[1].Value);
            string name = attributes[2].Value;
            string description = attributes[3].Value;
            int key = Int32.Parse(attributes[4].Value);
            return new Key(uin, name, description, key);
        }
    }
}