using System;
using TextAdventureItem;
using TextAdventureCharacter;
using System.Xml;
using System.Collections.Generic;
using TextAdventureMap;

namespace TextAdventureMap
{
    public class Gateway
    {
        protected int uniqueIdentificationNumber;
        protected Area areaA;
        protected Area areaB;
        public Gateway(int uniqueIdentificationNumber, Area areaA, Area areaB)
        {
            this.areaA = areaA;
            areaA.AddGateway(this);
            this.areaB = areaB;
            areaB.AddGateway(this);
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
        }
        public virtual void ChangeArea(Character character)
        {
            character.MoveToArea(GetDestination(character.GetLocation()));
            character.SetIsOnMove(false);
        }
        public virtual int GetUIN(Area callingArea)
        {
            return (callingArea == areaA)? areaB.GetUIN() : areaA.GetUIN();
        }
        public virtual string GetName(Area callingArea)
        {
            return GetDestinationName(callingArea);
        }
        public virtual string GetDescription(Area callingArea)
        {
            return GetName(callingArea) + " [" + GetUIN(callingArea) + "]";
        }
        public string GetDestinationName(Area callingArea)
        {
            return (callingArea == areaA)? areaB.GetName() : areaA.GetName();
        }
        protected Area GetDestination(Area callingArea)
        {
            return (callingArea == areaA)? areaB : areaA;
        }
        public static Gateway BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uin = Int32.Parse(attributes[1].Value);
            int uinAreaA = Int32.Parse(attributes[2].Value);
            int uinAreaB = Int32.Parse(attributes[3].Value);
            Area areaA = areaList.Find(area => area.GetUIN() == uinAreaA);
            Area areaB = areaList.Find(area => area.GetUIN() == uinAreaB);
            return new Gateway(uin, areaA, areaB);
        }
    }
}