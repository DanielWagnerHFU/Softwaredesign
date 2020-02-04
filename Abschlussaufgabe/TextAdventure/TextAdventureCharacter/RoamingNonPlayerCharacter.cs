using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class RoamingNonPlayerCharacter : NonPlayerCharacter
    {
        public RoamingNonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}