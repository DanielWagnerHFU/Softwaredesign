using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class PassicDialogNPC : NPC
    {
        
        public PassicDialogNPC(string name, string description) 
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
            _maxHealthPoints = 25;
            _healthPoints = 25;
            _strength = 5;
        }
        public override void GetHarmed(double damage)
        {
            //TAKES NO DMG
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            if(attacker.GetType() == typeof(PlayerCharacter))
            {
                Console.WriteLine("This character cannot be harmed");
            }
        }
        public override void MakeAMove()
        {

        }
        public static PassicDialogNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            return new PassicDialogNPC(name, description);
        }
    }
}