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
            _moodAboutCharacters = new Dictionary<Character, double>();
            _maxHealthPoints = 50;
            _healthPoints = 50;
            _strength = 10;
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, _attackMoodChange);
        }
        public override void MakeAMove(){
            _isOnMove = true;
            ManageAttackBehaviour();
            if(_isOnMove)
            {
                ManageRoamingBehaviour(50);
            }
        }
        protected override Character GetAttackTarget()
        {
            Character possibleAttackTarget = GetLowestMoodCharacter();
            if(possibleAttackTarget != null && _moodAboutCharacters.ContainsKey(possibleAttackTarget))
            {
                double mood = _moodAboutCharacters[possibleAttackTarget];
                if(mood < _moodAgressionThreshold){
                    return possibleAttackTarget;
                }  
            }
            return null;
        }
        private Character GetLowestMoodCharacter()
        {
            List<Character> characters = GetSupportingCharacters();
            List<Character> charactersAlive = characters.FindAll(c => c.GetIsAlive() == true);
            if(charactersAlive.Count > 0)
            {
                List<Character> moodCharacters = new List<Character>();
                foreach(Character characterAlive in charactersAlive)
                {
                    if(_moodAboutCharacters.ContainsKey(characterAlive))
                        moodCharacters.Add(characterAlive);
                }
                if(moodCharacters.Count > 0)
                {
                    Character lowestMoodCharacter = moodCharacters[0];
                    foreach(Character character in moodCharacters)
                    {
                        if(_moodAboutCharacters[character] < _moodAboutCharacters[lowestMoodCharacter])
                            lowestMoodCharacter = character;
                    }
                    return lowestMoodCharacter;
                }
            }
            return null;
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