using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class RoamingNonPlayerCharacter : NonPlayerCharacter
    {
        public RoamingNonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description, location, dialog)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}