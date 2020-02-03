using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        Dictionary<string[], Command> commands;
        public PlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            commands = new Dictionary<string[], Command>();
            initializeCommands();
        }
        private void initializeCommands()
        {
            this.commands.Add(new string[] {"quit","q"}, new Command(QuitGame,"quit(q)"));

            //TODO
        }
        public override void MakeAMove(){
            //TODO
        }
        public override void StartDialog(Character character)
        {
            character.StartDialog(this);
        }
        private void QuitGame(string[] args)
        {
            System.Environment.Exit(0);
        }
    }
}