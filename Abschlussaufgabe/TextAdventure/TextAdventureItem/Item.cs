using System;

namespace TextAdventureItem
{
    public abstract class Item
    {
        protected int uniqueIdentificationNumber;
        public Item(int uniqueIdentificationNumber){
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
        }
    }
}