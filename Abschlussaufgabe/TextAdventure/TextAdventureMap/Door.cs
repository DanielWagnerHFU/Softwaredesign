using System;
using TextAdventureItem;
using System.Xml;
using TextAdventureMap;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class Door : Gateway
    {
        private int keyHole;
        private string name;
        private bool isOpen;
        public Door(int uniqueIdentificationNumber, Area areaA, Area areaB, string name, int keyHole, bool isOpen) 
        : base(uniqueIdentificationNumber, areaA, areaB)
        {
            this.keyHole = keyHole;
            this.name = name;
            this.isOpen = isOpen;
        }
        public override string GetDescription(Area callingArea){
            if(isOpen == true)
            {
                return this.name + " open to " + GetDestinationName(callingArea) + " [" + callingArea.GetUIN() + "]";
            } 
            else 
            {
                return "closed " + this.name + " [" + this.uniqueIdentificationNumber + "]";
            }
        }
        public override string GetName(Area callingArea){
            return this.name;
        }
        public override int GetUIN(Area callingArea)
        {
            return this.uniqueIdentificationNumber;
        }
        public string GetName()
        {
            return this.name;
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
        public override void ChangeArea(Character character)
        {
            if(isOpen)
            {
                character.MoveToArea(GetDestination(character.GetLocation()));
                character.SetIsOnMove(false);
            }
            else
            {
                Console.WriteLine("This door is closed");
            }
        }
        new public static Door BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uin = Int32.Parse(attributes[1].Value);
            int uinAreaA = Int32.Parse(attributes[2].Value);
            int uinAreaB = Int32.Parse(attributes[3].Value);
            Area areaA = areaList.Find(area => area.GetUIN() == uinAreaA);
            Area areaB = areaList.Find(area => area.GetUIN() == uinAreaB);
            string name = attributes[4].Value;
            int keyHole = Int32.Parse(attributes[5].Value);
            bool isOpen = Boolean.Parse(attributes[6].Value);
            return new Door(uin, areaA, areaB, name, keyHole, isOpen);
        }
    }
}