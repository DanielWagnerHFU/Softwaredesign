using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int _key;
        public Key(string name, string description, int key) 
        : base(name, description)
        {
            _key = key;
        }
        private void SwitchDoorIsOpen(Door door)
        {
            if(door.GetIsOpen())
            {
                door.SetIsOpen(false);
                Console.WriteLine(door.GetName() + " just closed");
            }
            else
            {
                door.SetIsOpen(true);
                Console.WriteLine(door.GetName() + " just opened");
            }
        }
        private void UseKey(Door door, Character user)
        {
            if(_key == door.GetKeyHole())
            {
                SwitchDoorIsOpen(door);
                user.SetIsOnMove(false);
                UpdateItem(user);
            }
            else
            {
                Console.WriteLine("Thats the wrong key");
            }
        }
        public override void UseOnGateway(Gateway gateway, Character user)
        {
            if(gateway.GetType() == typeof(Door))
            {
                Door door = (Door)gateway;
                UseKey(door, user);
            }
            else
            {
                Console.WriteLine("ERROR: This is not a door");
            }
        }
        public static Key BuildFromXmlNode(XmlNode itemNode)
        {
            XmlAttributeCollection attributes = itemNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            int key = Int32.Parse(attributes[3].Value);
            return new Key(name, description, key);
        }
    }
}