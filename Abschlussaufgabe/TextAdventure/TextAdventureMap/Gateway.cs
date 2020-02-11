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
        protected Area _areaA;
        protected Area _areaB;

        public Gateway(Area areaA, Area areaB)
        {
            _areaA = areaA;
            areaA.AddGateway(this);
            _areaB = areaB;
            areaB.AddGateway(this);
        }

        public Gateway(Area area)
        {
            _areaA = area;
            _areaB = area;
            area.AddGateway(this);
        }

        public virtual void ChangeArea(Character character)
        {
            character.MoveToArea(GetDestination(character.GetLocation()));
            character.SetIsOnMove(false);
        }

        public virtual string GetName(Area callingArea) => GetDestinationName(callingArea);

        public virtual string GetDescription(Area callingArea) => GetName(callingArea);

        private string GetDestinationName(Area callingArea) => (callingArea == _areaA) ? _areaB.GetName() : _areaA.GetName();

        protected Area GetDestination(Area callingArea) => (callingArea == _areaA) ? _areaB : _areaA;

        public static Gateway BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uinAreaA = Int32.Parse(attributes[1].Value);
            int uinAreaB = Int32.Parse(attributes[2].Value);
            Area areaA = areaList.Find(area => area.GetUIN() == uinAreaA);
            Area areaB = areaList.Find(area => area.GetUIN() == uinAreaB);
            return new Gateway(areaA, areaB);
        }
    }
}