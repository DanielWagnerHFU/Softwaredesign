using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;
using TextAdventureItem;

namespace TextAdventureCharacter
{
    public sealed class DanielNPC : HumanNPC
    {
        public DanielNPC(string name, string description)
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
            _maxHealthPoints = 420;
            _healthPoints = 420;
            _strength = 5;
            _equippedItem = new DamageAmplifier("The argument of all arguments", "this argument is better then yours", 2);
        }

        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, _attackMoodChange);
        }

        public override void MakeAMove()
        {
            _isOnMove = true;
            ManageAttackBehaviour();
            if (_isOnMove)
                ManageRoamingBehaviour(50);
        }

        protected override Character GetAttackTarget()
        {
            Character possibleAttackTarget = GetLowestMoodCharacter();
            if (possibleAttackTarget != null && _moodAboutCharacters.ContainsKey(possibleAttackTarget))
            {
                double mood = _moodAboutCharacters[possibleAttackTarget];
                if (mood < _moodAgressionThreshold)
                    return possibleAttackTarget;
            }
            return null;
        }

        private Character GetLowestMoodCharacter()
        {
            List<Character> characters = GetSupportingCharacters();
            List<Character> charactersAlive = characters.FindAll(c => c.GetIsAlive());
            if (charactersAlive.Count > 0)
            {
                List<Character> moodCharacters = new List<Character>();
                foreach (Character characterAlive in charactersAlive)
                {
                    if (_moodAboutCharacters.ContainsKey(characterAlive))
                        moodCharacters.Add(characterAlive);
                }
                if (moodCharacters.Count > 0)
                {
                    return SearchLowestMoodCharacter(moodCharacters);
                }
            }
            return null;
        }

        private Character SearchLowestMoodCharacter(List<Character> characters)
        {
            Character lowestMoodCharacter = characters[0];
            foreach (Character character in characters)
            {
                if (_moodAboutCharacters[character] < _moodAboutCharacters[lowestMoodCharacter])
                    lowestMoodCharacter = character;
            }
            return lowestMoodCharacter;
        }

        new public static DanielNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            return new DanielNPC(name, description);
        }
    }
}