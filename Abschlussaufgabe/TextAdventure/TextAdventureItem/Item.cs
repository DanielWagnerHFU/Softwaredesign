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
        protected bool CharacterIsPlayer(Character character)
        {
            return(character.GetType() == typeof(PlayerCharacter))? true : false;
        }
        public abstract void UseOnCharacter(Character character, Character user);
        public abstract void UseOnGateway(Gateway gateway, Character user);
    }
}