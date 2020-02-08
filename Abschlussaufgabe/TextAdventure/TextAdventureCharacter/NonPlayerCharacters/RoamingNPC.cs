using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class RoamingNPC : NPC
    {
        public RoamingNPC(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}