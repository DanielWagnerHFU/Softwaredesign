using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class NPC : Character
    {
        protected double _attackMoodChange = -100;
        protected double _moodAgressionThreshold = -10;
        protected Dictionary<Character,double> moodAboutCharacters;
        public NPC(string name, string description) 
        : base(name, description)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, -100);
        }
        protected void ChangeMood(Character character, double moodChange)
        {
            if(moodAboutCharacters.ContainsKey(character))
            {
                moodAboutCharacters[character] += moodChange;
            }
            else
            {
                moodAboutCharacters.Add(character, moodChange);
            }
        }
        public override void MakeAMove()
        {
        }
        protected virtual void ManageRoamingBehaviour(int changeProbability)
        {
           List<Gateway> gateways = this._location.GetGateways();
           if (gateways.Count != 0)
           {
                Random random = new Random();
                if (random.Next(1, 101) <= changeProbability)
                {
                    int gatewayIndex = random.Next(gateways.Count);
                    ChangeArea(CorrectIndexPlus(gatewayIndex));
                }
           }
        }
        protected int CorrectIndexPlus(int index)
        {
            return index+1;
        }
        public override void StartDialog(Character character)
        {
            Console.WriteLine("ERROR: You cannot talk to this character");
        }
    }
}