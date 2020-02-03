using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class RoamingNonPlayerCharacter : NonPlayerCharacter
    {
        public RoamingNonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, location, dialog)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}