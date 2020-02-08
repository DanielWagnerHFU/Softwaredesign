using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class DialogNPC : NPC
    {
        protected DialogNode dialog;
        public DialogNPC(int uniqueIdentificationNumber, string name, string description, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description)
        {
            this.dialog = dialog;
        }

        public override void StartDialog(Character character)
        {
            //TODO
        }
    }
}