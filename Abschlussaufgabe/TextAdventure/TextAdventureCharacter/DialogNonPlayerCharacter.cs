using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class DialogNonPlayerCharacter : NonPlayerCharacter
    {
        protected DialogNode dialog;
        public DialogNonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            this.dialog = dialog;
        }

        public override void
    }
}