using System;
using TextAdventureItem;

namespace TextAdventureMap
{
    public class Door : Gateway
    {
        private Key referenceKey;
        private string name;
        private bool isOpen;
        public Door(Area areaA, Area areaB, Key referenceKey, string name, bool isOpen) 
        : base(areaA, areaB)
        {
            this.referenceKey = referenceKey;
            this.name = name;
            this.isOpen = isOpen;
        }
        public override void UseItem(Item item)
        {
            if(item.GetType() == typeof(Key))
            {
                Key key = (Key)item;
                if(referenceKey.GetKey() == key.GetKey())
                {
                    //TODO - open the door // add attribute for closed / open
                }
            }
        }
        public override string GetName(Area callingArea){
            if(isOpen == true)
            {
                return GetDestinationName(callingArea);
            } 
            else 
            {
                return this.name;
            }
        }
    }
}