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
            this.commands.Add(new Command(new string[]{"go to","gt"}, CommandHandlerGoTo, "go to(gt) <room>", 1));
            this.commands.Add(new Command(new string[]{"clear chat","cc"}, CommandHandlerClearChat, "clear chat(cc)"));
            this.commands.Add(new Command(new string[]{"talk to","tt"}, CommandHandlerTalkTo, "talk to(tt) <character>"));
            this.commands.Add(new Command(new string[]{"quit","q"}, CommandHandlerQuit, "quit(q)"));
        }
        public override void MakeAMove(){
            this.isOnMove = true;
            Console.Clear();
            CommandHandlerLook(new string[]{});
            while(this.isOnMove && this.isAlive)
            {
                Console.WriteLine();
                string userInput = EnterUserinput("What would you like to do?: ");
                Console.WriteLine();
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
        private void CommandHandlerTalkTo(string[] args)
        {
            Character character = FindCharacter(args[0]);
            if(character != null)
            {
               StartDialog(character);
               this.isOnMove = false;
            }
        }
        public override void StartDialog(Character character)
        {
            character.StartDialog(this);
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
            Console.WriteLine(this.location.GetDescription());
            WriteItems();
            WriteSupportingCharacters();
            WriteAdjacenAreas();
        }
        private void WriteAdjacenAreas()
        {
            List<Gateway> gateways = this.location.GetGateways();
            if(gateways.Count != 0)
            {
                Console.WriteLine("You can go to:");
                foreach(Gateway gateway in gateways)
                {
                    Console.WriteLine(gateway.GetName(this.location));
                }
            }
        }
        private void WriteSupportingCharacters()
        {
            List<Character> supportingCharacters = GetSupportingCharacters();
            if(supportingCharacters.Count != 0)
            {
                Console.WriteLine("Characters:");
                foreach(Character character in supportingCharacters)
                {
                    Console.WriteLine("name: " + character.GetName());
                    if(character.GetDescription() != "")
                        Console.WriteLine("description: " + character.GetDescription());
                }
            }
        }
        private void WriteItems()
        {
            List<Item> items = this.location.GetItems();
            if(items.Count != 0)
            {
                Console.WriteLine("Items:");
                foreach(Item item in items)
                {
                    Console.WriteLine("name: " + item.GetName());
                    if(item.GetDescription()!="")
                        Console.WriteLine("description: " + item.GetDescription());
                }
            }
        }
        private void CommandHandlerInventory(string[] args)
        {
            Console.WriteLine("In your inventory are the following Items:");
            foreach(Item item in this.inventory)
            {
                Console.WriteLine("name: " + item.GetName());
                if(item.GetDescription() != "")
                    Console.WriteLine("description: " + item.GetDescription());
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
            ChangeArea(args[0]);
            this.isOnMove = false;
        }
        private void CommandHandlerClearChat(string[] args)
        {
            Console.Clear();
        }
        private void CommandHandlerQuit(string[] args)
        {
            this.isAlive = false;
            this.isOnMove = false;
        }
    }
}