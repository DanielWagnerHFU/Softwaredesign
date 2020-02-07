using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class NonPlayerCharacter : Character
    {
        protected Dictionary<Character,double> moodAboutCharacters;
        public NonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            this.moodAboutCharacters = new Dictionary<Character, double>();
        }
        public override void MakeAMove(){
        }
        public override void StartDialog(Character character)
        {
            Console.WriteLine("ERROR: You cannot talk to this character");
        }
    }
}