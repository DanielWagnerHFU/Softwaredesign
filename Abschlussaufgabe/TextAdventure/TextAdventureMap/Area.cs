using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using TextAdventureItem;
using System.Xml;

namespace TextAdventureMap
{
    public class Area
    {
        protected int _uniqueIdentificationNumber;
        protected string _name;
        protected string _description;
        protected List<Gateway> _gateways;
        protected List<Character> _characters;
        protected List<Item> _items;

        public Area(int uniqueIdentificationNumber, string name, string description){
            _uniqueIdentificationNumber = uniqueIdentificationNumber;
            _name = name;
            _description = description;
            _gateways = new List<Gateway>();
            _characters = new List<Character>();
            _items = new List<Item>();
        }

        public string GetDescription()
        {
            return _description;
        }

        public string GetName()
        {
            return _name;
        }

        public List<Gateway> GetGateways()
        {
            return _gateways;
        }

        public void AddGateway(Gateway gateway)
        {
            _gateways.Add(gateway);
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public void AddCharacter(Character character)
        {
            _characters.Add(character);
            character.SetLocation(this);
        }

        public void RemoveCharacter(Character character)
        {
            _characters.Remove(character);
        }

        public List<Character> GetSupportingCharacters(Character mainCharacter)
        {
            List<Character> supportingCharacters = new List<Character>(_characters);
            supportingCharacters.Remove(mainCharacter);
            return supportingCharacters;
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public int GetUIN()
        {
            return _uniqueIdentificationNumber;
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