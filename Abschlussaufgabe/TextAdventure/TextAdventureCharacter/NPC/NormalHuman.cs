using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class NormalNonPlayerCharacter : NonPlayerCharacter
    {
        public NormalNonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
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
    }
}