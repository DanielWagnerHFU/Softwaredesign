using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class DialogNPC : NPC
    {
        protected DialogNode dialog;
        public DialogNPC(string name, string description, DialogNode dialog) 
        : base(name, description)
        {
            this.dialog = dialog;
        }

        public override void StartDialog(Character character)
        {
            //TODO
        }
    }
}