using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class StaticNonPlayerCharacter : NonPlayerCharacter
    {
        public StaticNonPlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location, DialogNode dialog) 
        : base(uniqueIdentificationNumber, name, description, location, dialog)
        {

        }
        public override void MakeAMove(){
            //Static NPC doesnt make moves
        }
    }
}