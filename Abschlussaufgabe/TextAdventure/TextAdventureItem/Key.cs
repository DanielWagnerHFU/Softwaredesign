using System;
using TextAdventureCharacter;
using TextAdventureMap;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int key;
        public Key(int uniqueIdentificationNumber, int key, string name, string description) : base(uniqueIdentificationNumber, name, description){
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
    }
}