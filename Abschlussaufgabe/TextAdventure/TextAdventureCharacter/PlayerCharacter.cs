using System;
using TextAdventureMap;
using System.Collections.Generic;
using TextAdventureItem;
using System.Xml;

namespace TextAdventureCharacter
{
    public class PlayerCharacter : Character
    {
        List<Command> commands;
        public PlayerCharacter(string name, string description, double strength = 10, double healthPoints = 100, double maxHealthPoints = 100) 
        : base(name, description, strength, healthPoints, maxHealthPoints)
        {
            commands = new List<Command>();
            initializeCommands();
            isOnMove = true;
            this.strength = 10;
            this.maxHealthPoints = 100;
            this.healthPoints = maxHealthPoints;
        }
        private void initializeCommands()
        {
            //TODO - Add new Commands here
            this.commands.Add(new Command(new string[]{"commands","c"}, CommandHandlerCommands, "commands(c)"));
            this.commands.Add(new Command(new string[]{"look at","la"}, CommandHandlerLookAt, "look at(la): <item or character>"));
            this.commands.Add(new Command(new string[]{"look","l"}, CommandHandlerLook, "look(l)"));
            this.commands.Add(new Command(new string[]{"inventory","i"}, CommandHandlerInventory, "inventory(i)"));
            this.commands.Add(new Command(new string[]{"take","t"}, CommandHandlerTake, "take(t): <item>", 1));
            this.commands.Add(new Command(new string[]{"drop","d"}, CommandHandlerDrop, "drop(d): <item>", 1));
            this.commands.Add(new Command(new string[]{"equip","e"}, CommandHandlerEquip, "equip(e): <item>", 1));
            this.commands.Add(new Command(new string[]{"use item on","uio"}, CommandHandlerUseItemOn, "use item on(uio) <gateway or character>", 1));
            this.commands.Add(new Command(new string[]{"use item","ui"}, CommandHandlerUseItem, "use item(ui)"));
            this.commands.Add(new Command(new string[]{"go to","gt"}, CommandHandlerGoTo, "go to(gt): <room>", 1));
            this.commands.Add(new Command(new string[]{"clear chat","cc"}, CommandHandlerClearChat, "clear chat(cc)"));
            this.commands.Add(new Command(new string[]{"talk to","tt"}, CommandHandlerTalkTo, "talk to(tt): <character>"));
            this.commands.Add(new Command(new string[]{"attack","a"}, CommandHandlerAttack, "attack(a): <character>", 1));
            this.commands.Add(new Command(new string[]{"quit","q"}, CommandHandlerQuit, "quit(q)"));
            this.commands.Add(new Command(new string[]{"status","s"}, CommandHandlerStatus, "status(s)"));
        }
        public override void MakeAMove(){
            this.isOnMove = true;
            Console.WriteLine();
            CommandHandlerStatus(new string[]{});
            CommandHandlerLook(new string[]{});
            while(this.isOnMove && this.isAlive)
            {
                Console.WriteLine();
                string userInput = EnterUserinput("What would you like to do? (write 'commands' for all options):");
                Console.WriteLine();
                HandleCommand(userInput);
            }
        }
        private string EnterUserinput(string inputMessage)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(inputMessage);
            Console.ForegroundColor = ConsoleColor.White;
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
        private void CommandHandlerStatus(string[] args)
        {
            Console.WriteLine(GetStatusString());
        }
        private void CommandHandlerLook(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this.location.GetDescription());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            WriteItems();
            WriteSupportingCharacters();
            WriteAdjacenAreas();
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void WriteAdjacenAreas()
        {
            List<Gateway> gateways = this.location.GetGateways();
            if(gateways.Count != 0)
            {
                Console.WriteLine("A list of gateways:");
                foreach(Gateway gateway in gateways)
                {
                    Console.WriteLine("  " + gateway.GetDescription(this.location));
                }
            }
        }
        private void WriteSupportingCharacters()
        {
            List<Character> supportingCharacters = GetSupportingCharacters();
            if(supportingCharacters.Count != 0)
            {
                Console.WriteLine("A list of characters:");
                foreach(Character character in supportingCharacters)
                {
                    if(character.GetIsAlive())
                    {
                        Console.WriteLine("  " + character.GetName() + " " + character.GetStatusString());
                    } 
                    else 
                    {
                        Console.WriteLine("  " + character.GetName() + " (dead)");
                    }
                }
            }
        }
        private void WriteItems()
        {
            List<Item> items = this.location.GetItems();
            if(items.Count != 0)
            {
                Console.WriteLine("A list of items:");
                foreach(Item item in items)
                {
                    Console.WriteLine("  " + item.GetName());
                }
            }
        }
        private void CommandHandlerInventory(string[] args)
        {
            Console.WriteLine("In your inventory are the following Items:");
            foreach(Item item in this.inventory)
            {
                Console.WriteLine("name: " + item.GetName());
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
        }
        private void CommandHandlerClearChat(string[] args)
        {
            Console.Clear();
        }
        private void CommandHandlerLookAt(string[] args)
        {
            Character character = GetSupportingCharacters().Find(_character => _character.GetName() == args[0]);
            Item itemL = this.location.GetItems().Find(_itemL => _itemL.GetName() == args[0]);
            Item itemI = this.inventory.Find(_itemI => _itemI.GetName() == args[0]);
            if((this.activeItem != null) && (this.activeItem.GetName() == args[0]))
            {
                Console.WriteLine("Item description: " + this.activeItem.GetDescription());
            }
            else if(character != null)
            {
                Console.WriteLine("Character description: " + character.GetDescription());
            } 
            else if(itemI != null) 
            {
                Console.WriteLine("Item description: " + itemI.GetDescription());
            } 
            else if(itemL != null) 
            {
                Console.WriteLine("Item description: " + itemL.GetDescription());
            }
            else 
            {
                Console.WriteLine("ERROR: Not found");
            }
        }
        private void CommandHandlerAttack(string[] args)
        {
            Attack(args[0]);
        }
        private void CommandHandlerEquip(string[] args)
        {
            bool isSwitched = SwitchActiveItem(args[0]);
            if(isSwitched)
            {
                Console.WriteLine("item equipped");
            }
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            Console.WriteLine("You have been attacked by " + attacker.GetName());
        }
        private void CommandHandlerUseItemOn(string[] args)
        {
            if(this.activeItem != null)
            {
                UseItemOn(args[0]);
            }
            else
            {
                Console.WriteLine("No item equipped");
            }
        }
        private void CommandHandlerUseItem(string[] args)
        {
            if(this.activeItem != null)
            {
                UseItem();
                this.isOnMove = false;
            }
            else
            {
                Console.WriteLine("No item equipped");
            }
        }
        private void CommandHandlerQuit(string[] args)
        {
            this.isAlive = false;
            this.isOnMove = false;
        }
        public static PlayerCharacter BuildFromXmlNode(XmlNode characterNode)
        {
            XmlAttributeCollection attributes = characterNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            double strength = Double.Parse(attributes[3].Value);
            double healthPoints = Double.Parse(attributes[4].Value);
            double maxHealthPoints = Double.Parse(attributes[5].Value);
            return new PlayerCharacter(name, description, strength, healthPoints, maxHealthPoints);
        }    
    }
}