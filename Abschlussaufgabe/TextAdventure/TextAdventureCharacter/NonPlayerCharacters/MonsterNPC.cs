using System;
using TextAdventureMap;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public class MonsterNPC : NPC
    {
        
        public MonsterNPC(string name, string description) 
        : base(name, description)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
            this._maxHealthPoints = 50;
            this._healthPoints = 50;
            this._strength = 20;
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
                ManageRoamingBehaviour(20);
            }
        }
        private void ManageAttackBehaviour()
        {
            Character possibleAttackTarget = GetRandomCharacter();
            if(possibleAttackTarget != null)
            {
                Attack(possibleAttackTarget.GetName());
                this._isOnMove = false;
            }
        }
        private Character GetRandomCharacter()
        {
            List<Character> targets = GetSupportingCharacters();
            if(targets.Count > 0)
            {
                Random random = new Random();
                Character target = targets[random.Next(targets.Count)];
                return (target.GetIsAlive())? target : null;
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