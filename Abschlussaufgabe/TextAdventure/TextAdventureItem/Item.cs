using System;
using TextAdventureCharacter;
using TextAdventureMap;

namespace TextAdventureItem
{
    public abstract class Item
    {
        protected string name;
        protected string description;
        public Item(string name, string description){
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