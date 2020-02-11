using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class MonsterNPC : AttackerNPC
    {
        public MonsterNPC(string name, string description)
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
            _maxHealthPoints = 25;
            _healthPoints = 25;
            _strength = 5;
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
                ManageRoamingBehaviour(20);
        }

        protected override Character GetAttackTarget()
        {
            List<Character> targets = GetSupportingCharacters();
            List<Character> aliveTargets = targets.FindAll(t => t.GetIsAlive());
            if(aliveTargets.Count > 0)
            {
                Random random = new Random();
                Character target = aliveTargets[random.Next(aliveTargets.Count)];
                return target;
            }
            else
            {
                return null;
            }
        }

        public override void StartDialog(Character character)
        {
            Console.WriteLine("ARRRRRRRRG");
        }

        public static MonsterNPC BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            return new MonsterNPC(name, description);
        }
    }
}