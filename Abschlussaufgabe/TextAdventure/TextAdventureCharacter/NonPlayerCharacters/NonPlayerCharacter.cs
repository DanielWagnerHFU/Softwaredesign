using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class NPC : Character
    {
        protected double attackMoodChange = -100;
        protected double moodAgressionThreshold = -10;
        protected Dictionary<Character,double> moodAboutCharacters;
        public NPC(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
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
        public override void MakeAMove(){
        }
        public override void StartDialog(Character character)
        {
            Console.WriteLine("ERROR: You cannot talk to this character");
        }
    }
}