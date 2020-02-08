using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public class HumanNPC : NPC
    {
        public HumanNPC(int uniqueIdentificationNumber, string name, string description) 
        : base(uniqueIdentificationNumber, name, description)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
            this.maxHealthPoints = 50;
            this.healthPoints = 50;
            this.strength = 10;
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, attackMoodChange);
        }
        public override void MakeAMove(){
            ManageAttackBehaviour();
        }
        protected void ManageAttackBehaviour()
        {
            Character possibleAttackTarget = getLowestMoodCharacter();
            double mood = moodAboutCharacters[possibleAttackTarget];
            if((possibleAttackTarget != null) && (mood < moodAgressionThreshold)){
                Attack(possibleAttackTarget.GetName());
            }
        }
        private Character getLowestMoodCharacter()
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
            int uin = Int32.Parse(attributes[1].Value);
            string name = attributes[2].Value;
            string description = attributes[3].Value;
            return new HumanNPC(uin, name, description);
        }  
    }
}