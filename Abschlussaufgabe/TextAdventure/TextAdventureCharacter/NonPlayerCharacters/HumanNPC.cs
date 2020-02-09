using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public class HumanNPC : NPC
    {
        public HumanNPC(string name, string description) 
        : base(name, description)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
            this._maxHealthPoints = 50;
            this._healthPoints = 50;
            this._strength = 10;
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, _attackMoodChange);
        }
        public override void MakeAMove(){
            ManageAttackBehaviour();
        }
        private void ManageAttackBehaviour()
        {
            Character possibleAttackTarget = GetLowestMoodCharacter();
            if(possibleAttackTarget != null)
            {
                double mood = moodAboutCharacters[possibleAttackTarget];
                if(mood < _moodAgressionThreshold){
                    Attack(possibleAttackTarget.GetName());
                }  
            }
        }
        private Character GetLowestMoodCharacter()
        {
            if(moodAboutCharacters.Count != 0)
            {
                List<Character> characters = new List<Character>(moodAboutCharacters.Keys);
                List<double> moods = new List<double>(moodAboutCharacters.Values);
                double lowestMood = moodAboutCharacters[characters[0]];
                foreach (double mood in moodAboutCharacters.Values)
                {
                    if (mood < lowestMood) lowestMood = mood;
                }
                return characters[moods.IndexOf(lowestMood)];
            }
            return null;
        }
        public override void StartDialog(Character character)
        {
            Console.WriteLine("Hello, i dont wanne talk");
        }
        public static HumanNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            return new HumanNPC(name, description);
        }  
    }
}