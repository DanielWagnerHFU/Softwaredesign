using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class StaticNonPlayerCharacter : NonPlayerCharacter
    {
        public StaticNonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, location, dialog)
        {

        }
        public override void MakeAMove(){
            //TODO - Static - also kein MakeAMove?
        }
    }
}