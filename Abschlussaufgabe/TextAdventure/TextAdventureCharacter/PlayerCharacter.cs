using System;
using TextAdventureMap;
namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(int uniqueIdentificationNumber, string name, Area location) 
        : base(uniqueIdentificationNumber, name, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
    }
}