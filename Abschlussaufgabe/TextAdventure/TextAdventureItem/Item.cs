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
            _name = name;
            _description = description;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetDescription()
        {
            return _description;
        }
        protected bool CharacterIsPlayer(Character character)
        {
            return(character.GetType() == typeof(PlayerCharacter))? true : false;
        }
        public virtual void UseOnGateway(Gateway gateway, Character user)
        {
            if(CharacterIsPlayer(user))
            {
                Console.WriteLine("You cannot use the item on this gateway");
            }            
        }        
        public virtual void UseOnCharacter(Character character, Character user)
        {
            if(CharacterIsPlayer(user))
            {
                Console.WriteLine("ERROR: You cannot use the item on this character");
            }   
        }
    }
}