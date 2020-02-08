using System;
using TextAdventureItem;
using System.Xml;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class Door : Gateway
    {
        private int keyHole;
        private string name;
        private bool isOpen;
        public Door(Area areaA, Area areaB, string name, int keyHole, bool isOpen) 
        : base(areaA, areaB)
        {
            this.keyHole = keyHole;
            this.name = name;
            this.isOpen = isOpen;
        }
        public override string GetName(Area callingArea){
            if(isOpen == true)
            {
                return this.name + " open to " + GetDestinationName(callingArea);
            } 
            else 
            {
                return this.name + " | closed";
            }
        }
        public bool IsOpen()
        {
            return isOpen;
        }
        public void SetIsOpen(bool isOpen)
        {
            this.isOpen = isOpen;
        }
        public int GetKeyHole()
        {
            return this.keyHole;
        }
        public static Door BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uinAreaA = Int32.Parse(attributes[1].Value);
            int uinAreaB = Int32.Parse(attributes[2].Value);
            Area areaA = areaList.Find(area => area.GetUIN() == uinAreaA);
            Area areaB = areaList.Find(area => area.GetUIN() == uinAreaB);
            string name = attributes[3].Value;
            int keyHole = Int32.Parse(attributes[4].Value);
            bool isOpen = Boolean.Parse(attributes[5].Value);
            return new Door(areaA, areaB, name, keyHole, isOpen);
        }
    }
}