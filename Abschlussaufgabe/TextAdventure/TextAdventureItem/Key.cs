using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Key : Item
    {
        private int key;
        public Key(string name, string description, int key) 
        : base(name, description)
        {
            this.key = key;
        }
        public override void UseOnCharacter(Character character, Character user)
        {
            if(CharacterIsPlayer(user))
            {
                Console.WriteLine("ERROR: You cannot use the item on this character");
            }   
        }
        private void SwitchDoorIsOpen(Door door)
        {
            if(door.IsOpen())
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
            if(this.key == door.GetKeyHole())
            {
                SwitchDoorIsOpen(door);
                user.SetIsOnMove(false);
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