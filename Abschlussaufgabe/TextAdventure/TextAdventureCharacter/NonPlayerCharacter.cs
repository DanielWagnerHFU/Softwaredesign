using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class NonPlayerCharacter : Character
    {
        protected DialogNode dialog;
        protected Dictionary<Character,double> moodAboutCharacters;
        public NonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            this.dialog = dialog;
            this.moodAboutCharacters = new Dictionary<Character, double>();
        }
        public override void StartDialog(Character character)
        {
            //TODO - erst nach DialogNode
        }
    }
}