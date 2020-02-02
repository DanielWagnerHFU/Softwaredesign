using System;
using TextAdventureItem;

namespace TextAdventureMap
{
    public class Door : Gateway
    {
        private Key referenceKey;
        public Door(Key referenceKey, Area areaA, Area areaB, int uniqueIdentificationNumber) 
        : base(areaA, areaB, uniqueIdentificationNumber)
        {
            this.referenceKey = referenceKey;
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
    }
}