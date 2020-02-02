using System;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int key;
        public Key(int uniqueIdentificationNumber, int key) : base(uniqueIdentificationNumber){
            this.key = key;
        }
        public int GetKey()
        {
            return this.key;
        }
    }
}