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
        private int _keyHole;
        private string _name;
        private bool _isOpen;
        public Door(Area areaA, Area areaB, string name, int keyHole, bool isOpen) 
        : base(areaA, areaB)
        {
            this._keyHole = keyHole;
            this._name = name;
            this._isOpen = isOpen;
        }
        public override string GetDescription(Area callingArea){
            if(_isOpen == true)
            {
                return this._name + " open to " + GetDestinationName(callingArea);
            } 
            else 
            {
                return "closed " + this._name;
            }
        }
        public override string GetName(Area callingArea){
            return this._name;
        }
        public string GetName()
        {
            return this._name;
        }
        public bool GetIsOpen()
        {
            return _isOpen;
        }
        public void SetIsOpen(bool isOpen)
        {
            this._isOpen = isOpen;
        }
        public int GetKeyHole()
        {
            return this._keyHole;
        }
        public override void ChangeArea(Character character)
        {
            if(_isOpen)
            {
                character.MoveToArea(GetDestination(character.GetLocation()));
                character.SetIsOnMove(false);
            }
            else if(character.GetType() == typeof(PlayerCharacter))
            {
                Console.WriteLine("This door is closed");
            }
        }
        new public static Door BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList){
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