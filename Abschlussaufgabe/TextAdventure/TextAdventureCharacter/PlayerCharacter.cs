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
            isOnMove = true;
        }
        private void initializeCommands()
        {
            this.commands.Add(new Command(new string[]{"commands","c"}, CommandHandlerCommands, "commands(c)"));
            this.commands.Add(new Command(new string[]{"look","l"}, CommandHandlerLook, "look(l)"));
            this.commands.Add(new Command(new string[]{"inventory","i"}, CommandHandlerInventory, "inventory(i)"));
            
            this.commands.Add(new Command(new string[]{"quit","q"}, CommandHandlerQuit, "quit(q)"));
        }
        public override void MakeAMove(){
            this.isOnMove = true;
            while(this.isOnMove)
            {
                string input = Console.ReadLine();
                HandleCommand(input);
            }
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
        public bool GetIsAlive()
        {
            return this.isAlive;
        }        
        public override void StartDialog(Character character)
        {
            character.StartDialog(this);
        }
        private void StartDialogWith(string[] args)
        {
            //TODO
        }
        private void CommandHandlerCommands(string[] args)
        {
            //TODO
        }
        private void CommandHandlerLook(string[] args)
        {
            //TODO
        }
        private void CommandHandlerInventory(string[] args)
        {
            //TODO
        }
        private void CommandHandlerTake(string[] args)
        {
            //TODO
        }
        private void CommandHandlerDrop(string[] args)
        {
            //TODO
        }
        private void CommandHandlerQuit(string[] args)
        {
            this.isAlive = false;
            this.isOnMove = false;
        }
    }
}