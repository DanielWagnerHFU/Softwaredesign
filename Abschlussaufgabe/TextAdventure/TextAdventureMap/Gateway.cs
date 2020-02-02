using System;
using TextAdventureItem;
using TextAdventureCharacter;

namespace TextAdventureMap
{
    public class Gateway
    {
        protected int uniqueIdentificationNumber;
        protected Area areaA;
        protected Area areaB;
        public Gateway(Area areaA, Area areaB, int uniqueIdentificationNumber)
        {
            this.areaA = areaA;
            areaA.AddGateway(this);
            this.areaB = areaB;
            areaB.AddGateway(this);
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
        }
        public virtual void UseItem(Item item){
            Console.WriteLine("Nothing happend");
        }
        public virtual void ChangeArea(Character character)
        {
            //TODO
        }
        public virtual string GetDescription(Area callingArea)
        {
            return (callingArea == areaA)? areaB.GetName() : areaA.GetName();
        }
    }
}