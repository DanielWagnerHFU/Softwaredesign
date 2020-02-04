using System;
using TextAdventureMap;
using System.Collections.Generic;
using TextAdventureItem;

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
            //TODO - Add new Commands here
            this.commands.Add(new Command(new string[]{"commands","c"}, CommandHandlerCommands, "commands(c)"));
            this.commands.Add(new Command(new string[]{"look","l"}, CommandHandlerLook, "look(l)"));
            this.commands.Add(new Command(new string[]{"inventory","i"}, CommandHandlerInventory, "inventory(i)"));
            this.commands.Add(new Command(new string[]{"take","t"}, CommandHandlerTake, "take(t) <item>", 1));
            this.commands.Add(new Command(new string[]{"drop","d"}, CommandHandlerDrop, "drop(d) <item>", 1));
            this.commands.Add(new Command(new string[]{"go to","mt"}, CommandHandlerGoTo, "go to(gt) <room>", 1));
            this.commands.Add(new Command(new string[]{"quit","q"}, CommandHandlerQuit, "quit(q)"));
        }
        public override void MakeAMove(){
            this.isOnMove = true;
            while(this.isOnMove && this.isAlive)
            {
                string userInput = EnterUserinput("What would you like to do?: ");
                HandleCommand(userInput);
            }
        }
        private string EnterUserinput(string inputMessage)
        {
            Console.Write(inputMessage);
            string userInput = Console.ReadLine();
            return userInput;
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
                if(command.GetArgumentsCount() <= args.Length){
                    command.GetMethodToCall()(args);
                } 
                else 
                {
                    Console.WriteLine("Error: not enough arguments");
                }
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
            Console.WriteLine("[" + string.Join(", ", GetCommandDescriptions()) + "]");
        }
        private string[] GetCommandDescriptions()
        {
            string[] commandDescriptions = new string[this.commands.Count];
            for(int i = 0; i < this.commands.Count; i++)
            {
                commandDescriptions[i] = this.commands[i].GetDescription();
            }
            return commandDescriptions;
        }
        private void CommandHandlerLook(string[] args)
        {
            Console.WriteLine(this.location.GetDescription() + " You see");
            WriteItems();
            Console.WriteLine("With you in the room are");
            WriteSupportingCharacters();
            //TODO add next rooms
        }
        private void WriteSupportingCharacters()
        {
            List<Character> supportingCharacters = GetSupportingCharacters();
            foreach(Character character in supportingCharacters)
            {
                Console.WriteLine(character.GetName());
                Console.WriteLine(character.GetDescription());
            }
            Console.WriteLine();
        }
        private void WriteItems()
        {
            List<Item> items = this.location.GetItems();
            foreach(Item item in items)
            {
                Console.WriteLine(item.GetName());
                Console.WriteLine(item.GetDescription());
            }
            Console.WriteLine();
        }
        private void CommandHandlerInventory(string[] args)
        {
            Console.WriteLine("In your inventory are the following Items:");
            foreach(Item item in this.inventory)
            {
                Console.WriteLine(item.GetName());
                Console.WriteLine(item.GetDescription());
            }
        }
        private void CommandHandlerTake(string[] args)
        {
            TakeItem(args[0]);
        }
        private void CommandHandlerDrop(string[] args)
        {
            DropItem(args[0]);
        }
        private void CommandHandlerGoTo(string[] args)
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