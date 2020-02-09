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
            this._uniqueIdentificationNumber = uniqueIdentificationNumber;
            this._name = name;
            this._description = description;
            this._gateways = new List<Gateway>();
            this._characters = new List<Character>();
            this._items = new List<Item>();
        }
        public string GetDescription()
        {
            return this._description;
        }
        public string GetName()
        {
            return this._name;
        }
        public List<Gateway> GetGateways()
        {
            return this._gateways;
        }
        public void AddGateway(Gateway gateway)
        {
            this._gateways.Add(gateway);
        }
        public void AddItem(Item item)
        {
            this._items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            this._items.Remove(item);
        }
        public void AddCharacter(Character character)
        {
            this._characters.Add(character);
            character.SetLocation(this);
        }
        public void RemoveCharacter(Character character)
        {
            this._characters.Remove(character);
        }
        public List<Character> GetSupportingCharacters(Character mainCharacter)
        {
            List<Character> supportingCharacters = new List<Character>(this._characters);
            supportingCharacters.Remove(mainCharacter);
            return supportingCharacters;
        }
        public List<Item> GetItems()
        {
            return this._items;
        }
        public List<Character> GetCharacters()
        {
            return this._characters;
        }
        public int GetUIN()
        {
            return this._uniqueIdentificationNumber;
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