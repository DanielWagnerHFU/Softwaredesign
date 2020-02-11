using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureItem
{
    public abstract class Item
    {
        protected string _name;
        protected string _description;
        protected List<Item> _spawnOnUseItems;

        protected Item(string name, string description){
            _name = name;
            _description = description;
            _spawnOnUseItems = new List<Item>();
        }

        public string GetName()
        {
            return _name;
        }

        public void AddSpawnItem(Item item)
        {
            _spawnOnUseItems.Add(item);
        }

        public string GetDescription()
        {
            return _description;
        }

        protected bool CharacterIsPlayer(Character character)
        {
            return character.GetType() == typeof(PlayerCharacter);
        }

        protected void UpdateItem(Character user)
        {
            if(user.GetType() == typeof(PlayerCharacter))
            {
                foreach(Item item in _spawnOnUseItems)
                {
                    user.GetLocation().GetItems().Add(item);
                }
            }
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