using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;
using TextAdventureItem;

namespace TextAdventureCharacter
{
    public sealed class GatekeeperNPC : PassivDialogNPC
    {
        public GatekeeperNPC(string name, string description, Key key)
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
            _maxHealthPoints = 25;
            _healthPoints = 25;
            _strength = 5;
            _equippedItem = key;
        }

        private void OpenDoor()
        {
            List<Gateway> gateways = _location.GetGateways();
            for(int i = 0; i < gateways.Count; i++)
                UseEquippedItemOnGateway(CorrectIndexPlus(i));
        }

        public override void StartDialog(Character character)
        {
            if (_dialog != null)
            {
                _dialog.UseDialogNode((PlayerCharacter)character, this);
                OpenDoor();
                Console.ReadKey(false);
            }
            else
            {
                Console.WriteLine("This character cannot talk");
            }
        }

        new public static GatekeeperNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            int keyValue = Convert.ToInt32(attributes[3].Value);
            Key key = new Key("Key","Opens stuff", keyValue);
            return new GatekeeperNPC(name, description, key);
        }
    }
}