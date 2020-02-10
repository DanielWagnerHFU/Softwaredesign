using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class HumanNPC : AttackerNPC
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
            this._isOnMove = true;
            ManageAttackBehaviour();
            if(this._isOnMove)
            {
                ManageRoamingBehaviour(50);
            }
        }
        protected override Character GetAttackTarget()
        {
            Character possibleAttackTarget = GetLowestMoodCharacter();
            if(possibleAttackTarget != null && possibleAttackTarget.GetIsAlive())
            {
                double mood = moodAboutCharacters[possibleAttackTarget];
                if(mood < _moodAgressionThreshold){
                    return possibleAttackTarget;
                }  
            }
            return null;
        }
        private Character GetLowestMoodCharacter()
        {
            if(moodAboutCharacters.Count != 0)
            {
                List<Character> characters = GetSupportingCharacters();
                List<double> moods = new List<double>();
                foreach(Character character in characters)
                {
                    if(moodAboutCharacters.ContainsKey(character))
                        moods.Add(moodAboutCharacters[character]);
                }
                double lowestMood = moodAboutCharacters[characters[0]];
                foreach (double mood in moodAboutCharacters.Values)
                {
                    if (mood < lowestMood) lowestMood = mood;
                }
                Character target = characters[moods.IndexOf(lowestMood)];
                return (target.GetIsAlive())? target : null;
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