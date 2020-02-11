using System;
using TextAdventureItem;
using System.Xml;
using TextAdventureMap;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class Portal : Gateway
    {
        private readonly List<Area> _areas;
        private readonly string _name;

        public Portal(Area area, string name, List<Area> areas)
        : base(area)
        {
            _areas = areas;
            _name = name;
        }

        public override string GetName(Area callingArea) => _name;

        public override string GetDescription(Area callingArea) => _name;

        public override void ChangeArea(Character character)
        {
            Random random = new Random();
            Area destination = _areas[random.Next(_areas.Count)];
            character.MoveToArea(destination);
            character.SetIsOnMove(false);
        }

        new public static Portal BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uinAreaA = Int32.Parse(attributes[1].Value);
            Area areaX = areaList.Find(area => area.GetUIN() == uinAreaA);
            string name = attributes[2].Value;
            return new Portal(areaX, name, areaList);
        }
    }
}