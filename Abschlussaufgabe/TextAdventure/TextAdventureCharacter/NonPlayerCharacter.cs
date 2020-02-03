using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class NonPlayerCharacter : Character
    {
        protected DialogNode dialog;
        protected Dictionary<Character,double> moodAboutCharacters;
        public NonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, location)
        {
            this.dialog = dialog;
            this.moodAboutCharacters = new Dictionary<Character, double>();
        }
        protected void StartDialog()
        {
            //TODO - erst nach DialogNode
        }
    }
}