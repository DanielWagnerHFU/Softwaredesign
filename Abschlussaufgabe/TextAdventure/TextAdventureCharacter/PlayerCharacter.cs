using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        List<Command> commands;
        public PlayerCharacter(int uniqueIdentificationNumber, string name, string description, Area location) 
        : base(uniqueIdentificationNumber, name, description, location)
        {
            commands = new List<Command>();
            initializeCommands();
        }
        private void initializeCommands()
        {
            this.commands.Add(new Command(new string[]{"quit","q"},QuitGame,"quit(q)"));
            //TODO
        }
        public override void MakeAMove(){
            //TODO
        }
        private void CommandHandler(string commandWithArgs)
        {
            //TODO
            foreach(Command command in commands)
            {
                if(command.IsEqualToCommandWithArgs(commandWithArgs))
                {
                    string[] args = command.GetArgs(commandWithArgs);
                    command.GetMethodToCall()(args);
                }
            }
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