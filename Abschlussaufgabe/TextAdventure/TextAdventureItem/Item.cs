using System;
using TextAdventureCharacter;
using TextAdventureMap;

namespace TextAdventureItem
{
    public abstract class Item
    {
        protected int uniqueIdentificationNumber;
        protected string name;
        protected string description;
        public Item(int uniqueIdentificationNumber, string name, string description){
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
            this.name = name;
            this.description = description;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public abstract void UseOnCharacter(Character character);
        public abstract void UseOnGateway(Gateway gateway);
    }
}