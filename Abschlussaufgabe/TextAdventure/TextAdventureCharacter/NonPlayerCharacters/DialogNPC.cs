using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class DialogNPC : NPC
    {
        protected DialogNode _dialog;
        public DialogNPC(string name, string description, DialogNode dialog) 
        : base(name, description)
        {
            this._dialog = dialog;
        }
        public override void StartDialog(Character character)
        {
            //TODO
        }
    }
}