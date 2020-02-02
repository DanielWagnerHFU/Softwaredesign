using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class RoamingNonPlayerCharacter : NonPlayerCharacter
    {
        public RoamingNonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location) 
        : base(uniqueIdentificationNumber, name, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}