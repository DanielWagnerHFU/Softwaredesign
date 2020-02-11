using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class BigMonsterNPC : MonsterNPC
    {
        public BigMonsterNPC(string name, string description, double strength, double healthPoints, double maxHealthPoints)
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
            _strength = strength;
            _maxHealthPoints = maxHealthPoints;
            _healthPoints = healthPoints;
        }

        protected override Character GetAttackTarget()
        {
            List<Character> targets = GetSupportingCharacters();
            List<Character> aliveTargets = targets.FindAll(t => t.GetIsAlive());
            List<Character> notBigMonsterTargets = aliveTargets.FindAll(t => t.GetType() != typeof(BigMonsterNPC));
            if (notBigMonsterTargets.Count > 0)
            {
                Random random = new Random();
                Character target = notBigMonsterTargets[random.Next(notBigMonsterTargets.Count)];
                return target;
            }
            else
            {
                return null;
            }
        }

        public override void StartDialog(Character character) => Console.WriteLine("ARRRRRRRRG");

        new public static BigMonsterNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            double strength = Double.Parse(attributes[3].Value);
            double healthPoints = Double.Parse(attributes[4].Value);
            double maxHealthPoints = Double.Parse(attributes[5].Value);
            return new BigMonsterNPC(name, description, strength, healthPoints, maxHealthPoints);
        }
    }
}