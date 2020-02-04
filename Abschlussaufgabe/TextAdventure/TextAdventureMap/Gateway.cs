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
            character.MoveToArea(GetDestination(character.GetLocation()));
        }
        public virtual string GetName(Area callingArea)
        {
            return GetDestinationName(callingArea);
        }
        protected string GetDestinationName(Area callingArea)
        {
            return (callingArea == areaA)? areaB.GetName() : areaA.GetName();
        }
        protected Area GetDestination(Area callingArea)
        {
            return (callingArea == areaA)? areaB : areaA;
        }
    }
}