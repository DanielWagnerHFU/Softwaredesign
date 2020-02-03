using System;
using TextAdventureMap;
namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
        public override void StartDialog(Character character)
        {

        }
    }
}