using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public class Potion : Item
    {
        private double _hpChange;
        public Potion(string name, string description, double hpChange) 
        : base(name, description)
        {
            _hpChange = hpChange;
        }
        public override void UseOnCharacter(Character character, Character user)
        {
            if(_hpChange < 0)
            {
                character.GetAttacked(-_hpChange ,user);
            }
            else
            {
                character.GetHealed(_hpChange);
            }
            user.SetIsOnMove(false);
        }
        public override void UseOnGateway(Gateway gateway, Character user)
        {
            if(CharacterIsPlayer(user))
            {
                Console.WriteLine("You cannot use the item on this gateway");
            }            
        }
        public static Potion BuildFromXmlNode(XmlNode itemNode)
        {
            XmlAttributeCollection attributes = itemNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            double hpChange = Convert.ToDouble(attributes[3].Value);
            return new Potion(name, description, hpChange);
        }
    }
}