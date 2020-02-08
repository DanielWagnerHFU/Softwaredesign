using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using TextAdventureItem;
using System.Xml;

namespace TextAdventureMap
{
    public class Area
    {
        protected int uniqueIdentificationNumber;
        protected string name;
        protected string description;
        protected List<Gateway> gateways;
        protected List<Character> characters;
        protected List<Item> items;
        public Area(int uniqueIdentificationNumber, string name, string description){
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
            this.name = name;
            this.description = description;
            this.gateways = new List<Gateway>();
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }
        public string GetDescription()
        {
            return this.description;
        }
        public string GetName()
        {
            return this.name;
        }
        public List<Gateway> GetGateways()
        {
            return this.gateways;
        }
        public void AddGateway(Gateway gateway)
        {
            this.gateways.Add(gateway);
        }
        public void AddItem(Item item)
        {
            this.items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
        }
        public void AddCharacter(Character character)
        {
            this.characters.Add(character);
            character.SetLocation(this);
        }
        public void RemoveCharacter(Character character)
        {
            this.characters.Remove(character);
        }
        public List<Character> GetSupportingCharacters(Character mainCharacter)
        {
            List<Character> supportingCharacters = new List<Character>(this.characters);
            supportingCharacters.Remove(mainCharacter);
            return supportingCharacters;
        }
        public List<Item> GetItems()
        {
            return this.items;
        }
        public static Area BuildFromXmlNode(XmlNode areaNode)
        {
            XmlAttributeCollection attributes = areaNode.Attributes;
            int uin = Int32.Parse(attributes[1].Value);
            string name = attributes[2].Value;
            string description = attributes[3].Value;
            return new Area(uin, name, description);
        }
    }
}