using System;
using TextAdventureCharacter;
using TextAdventureMap;

namespace TextAdventureItem
{
    public abstract class Item
    {
        protected string _name;
        protected string _description;
        public Item(string name, string description){
            this._name = name;
            this._description = description;
        }
        public string GetName()
        {
            return this._name;
        }
        public string GetDescription()
        {
            return this._description;
        }
        protected bool CharacterIsPlayer(Character character)
        {
            return(character.GetType() == typeof(PlayerCharacter))? true : false;
        }
        public abstract void UseOnCharacter(Character character, Character user);
        public abstract void UseOnGateway(Gateway gateway, Character user);
    }
}