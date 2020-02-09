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
        protected int _uniqueIdentificationNumber;
        protected Area _areaA;
        protected Area _areaB;
        public Gateway(int uniqueIdentificationNumber, Area areaA, Area areaB)
        {
            this._areaA = areaA;
            areaA.AddGateway(this);
            this._areaB = areaB;
            areaB.AddGateway(this);
            this._uniqueIdentificationNumber = uniqueIdentificationNumber;
        }
        public virtual void ChangeArea(Character character)
        {
            character.MoveToArea(GetDestination(character.GetLocation()));
            character.SetIsOnMove(false);
        }
        public virtual int GetUIN(Area callingArea)
        {
            return (callingArea == _areaA)? _areaB.GetUIN() : _areaA.GetUIN();
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
            return (callingArea == _areaA)? _areaB.GetName() : _areaA.GetName();
        }
        protected Area GetDestination(Area callingArea)
        {
            return (callingArea == _areaA)? _areaB : _areaA;
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