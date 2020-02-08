using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class DialogNPC : NonPlayerCharacter
    {
        protected DialogNode dialog;
        public DialogNPC(int uniqueIdentificationNumber, string name, string description, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            this.dialog = dialog;
        }

        public override void StartDialog(Character character)
        {
            //TODO
        }
    }
}