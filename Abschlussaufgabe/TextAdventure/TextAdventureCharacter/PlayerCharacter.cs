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
            string input = Console.ReadLine();
            HandleCommand(input);
        }
        private Command FindCommand(string commandWithArgs)
        {
            foreach(Command command in commands)
            {
                if(command.IsEqualToCommandWithArgs(commandWithArgs))
                {
                    return command;
                }
            }
            Console.WriteLine("Command not found - try to use the correct Syntax");
            return null;
        }
        private void HandleCommand(string commandWithArgs)
        {
            Command command = FindCommand(commandWithArgs);
            if(command != null)
            {
                string[] args = command.GetArgs(commandWithArgs);
                command.GetMethodToCall()(args);
            }
        }
        public override void StartDialog(Character character)
        {
            character.StartDialog(this);
        }
        private bool QuitGame(string[] args)
        {
            System.Environment.Exit(0);
            return false;
        }
    }
}