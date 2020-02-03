using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        delegate void ParameterMethod<T>(params T[] args);
        Dictionary<string, ParameterMethod<string>> commands;
        public PlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {

        }
        public override void MakeAMove(){
            //TODO
        }
        public override void StartDialog(Character character)
        {
            character.StartDialog(this);
        }
        private void QuitGame()
        {
            System.Environment.Exit(0);
        }
    }
}