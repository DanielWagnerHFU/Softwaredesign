using System;
using TextAdventureMap;
using System.Collections.Generic;
using TextAdventureItem;
using System.Xml;
using System.Threading;

namespace TextAdventureCharacter
{
    public sealed class PlayerCharacter : Character
    {
        private List<Command> _commandList;
        public PlayerCharacter(string name, string description, double strength = 10, double healthPoints = 100, double maxHealthPoints = 100) 
        : base(name, description, strength, healthPoints, maxHealthPoints)
        {
            _commandList = new List<Command>();
            InitializeCommands();
            _isOnMove = true;
            _strength = 10;
            _maxHealthPoints = 100;
            _healthPoints = maxHealthPoints;
        }
        private void InitializeCommands()
        {
            //TODO - Add new Commands here
            _commandList.Add(new Command(new string[]{"commands","c"}, CommandHandlerCommands, "commands(c)"));
            _commandList.Add(new Command(new string[]{"get item description","gid"}, CommandHandlerGetItemDescription, "get item description(gid)"));
            _commandList.Add(new Command(new string[]{"look","l"}, CommandHandlerLook, "look(l)"));
            _commandList.Add(new Command(new string[]{"inventory","i"}, CommandHandlerInventory, "inventory(i)"));
            _commandList.Add(new Command(new string[]{"take","t"}, CommandHandlerTake, "take(t): <index>", 1));
            _commandList.Add(new Command(new string[]{"drop","d"}, CommandHandlerDrop, "drop(d): <index>", 1));
            _commandList.Add(new Command(new string[]{"equip","e"}, CommandHandlerEquip, "equip(e): <index>", 1));
            _commandList.Add(new Command(new string[]{"use item on gateway","uiog"}, CommandHandlerUseItemOnGateway, "use item on gateway(uiog): <index>", 1));
            _commandList.Add(new Command(new string[]{"use item on character","uioc"}, CommandHandlerUseItemOnCharacter, "use item on character(uioc): <index>", 1));
            _commandList.Add(new Command(new string[]{"use item","ui"}, CommandHandlerUseItem, "use item(ui)"));
            _commandList.Add(new Command(new string[]{"go to","gt"}, CommandHandlerGoTo, "go to(gt): <index>", 1));
            _commandList.Add(new Command(new string[]{"clear chat","cc"}, CommandHandlerClearChat, "clear chat(cc)"));
            _commandList.Add(new Command(new string[]{"talk to","tt"}, CommandHandlerTalkTo, "talk to(tt): <index>"));
            _commandList.Add(new Command(new string[]{"attack","a"}, CommandHandlerAttack, "attack(a): <index>", 1));
            _commandList.Add(new Command(new string[]{"quit","q"}, CommandHandlerQuit, "quit(q)"));
            _commandList.Add(new Command(new string[]{"status","s"}, CommandHandlerStatus, "status(s)"));
        }
        public override void MakeAMove(){
            _isOnMove = true;
            Console.WriteLine();
            CommandHandlerStatus(new string[]{});
            CommandHandlerLook(new string[]{});
            while(_isOnMove && _isAlive)
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
            foreach(Command command in _commandList)
            {
                if(command.IsEqualToCommand(commandWithArgs))
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
        public override void GetHarmed(double damage)
        {
            _healthPoints -= damage;
            UpdateIsAlive();
        }
        protected override void UpdateIsAlive()
        {
            if (_healthPoints <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                _isAlive = false;
                Console.WriteLine("\n\n\n");
                Console.WriteLine("You died and so you lost! But just restart the game to get alive again ;D");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(10000);
            }
        }        
        private void CommandHandlerTalkTo(string[] args)
        {
            Character character = GetSupportingCharacters()[CorrectIndex(Convert.ToInt32(args[0]))];
            StartDialog(character);
            _isOnMove = false;
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
            string[] commandDescriptions = new string[_commandList.Count];
            for(int i = 0; i < _commandList.Count; i++)
            {
                commandDescriptions[i] = _commandList[i].GetDescription();
            }
            return commandDescriptions;
        }
        private void CommandHandlerStatus(string[] args)
        {
            Console.WriteLine(GetStatus());
        }
        private void CommandHandlerLook(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_location.GetDescription());
            Console.ForegroundColor = ConsoleColor.Green;
            WriteItems();
            CommandHandlerInventory(new string[]{});
            WriteSupportingCharacters();
            WriteAdjacenAreas();
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void WriteAdjacenAreas()
        {
            List<Gateway> gateways = _location.GetGateways();
            if(gateways.Count != 0)
            {
                Console.WriteLine("A list of gateways:");
                for(int i = 0; i < gateways.Count; i++)
                {
                    Console.WriteLine(" " + (i+1) + ":" + gateways[i].GetDescription(_location));
                }
            }
        }
        private void WriteSupportingCharacters()
        {
            List<Character> supportingCharacters = GetSupportingCharacters();
            if(supportingCharacters.Count != 0)
            {
                Console.WriteLine("A list of characters:");
                for(int i = 0; i < supportingCharacters.Count; i++)
                {
                    if(supportingCharacters[i].GetIsAlive())
                    {
                        Console.WriteLine(" " + (i+1) + ":" + supportingCharacters[i].GetName() + " " + supportingCharacters[i].GetStatus());
                    } 
                    else 
                    {
                        Console.WriteLine(" " + (i+1) + ":" + supportingCharacters[i].GetName() + " (dead)");
                    }
                }
            }
        }
        private void WriteItems()
        {
            List<Item> items = _location.GetItems();
            if(items.Count != 0)
            {
                Console.WriteLine("A list of items in the area:");
                for(int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine(" " + (i+1) + ":" + items[i].GetName());
                }
            }
        }
        private void CommandHandlerInventory(string[] args)
        {
            Console.WriteLine("A list of items in your inventory:");
            if(_inventory.Count != 0)
            {
                for(int i = 0; i < _inventory.Count; i++)
                {
                    Console.WriteLine(" " + (i+_location.GetItems().Count+1) + ":" + _inventory[i].GetName());
                }
            }
            else
            {
                Console.WriteLine(" Empty - use command take to fill your inventory");
            }
        }
        private void CommandHandlerTake(string[] args)
        {
            if(_inventory.Count <= _maxInventorySlots)
            {
                try
                {
                    TakeItem(Convert.ToInt32(args[0]));
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Your inventory is full. You only have " + _maxInventorySlots + " free itemslots!");
            }
        }
        private void CommandHandlerDrop(string[] args)
        {
            try
            {
                DropItem(Convert.ToInt32(args[0]));
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void CommandHandlerGoTo(string[] args)
        {
            try
            {
                ChangeArea(Convert.ToInt32(args[0]));
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void CommandHandlerClearChat(string[] args)
        {
            Console.Clear();
        }
        private void CommandHandlerGetItemDescription(string[] args)
        {
            if(_equippedItem != null)
            {
            Console.WriteLine("Description of " + _equippedItem.GetName() + ": " + _equippedItem.GetDescription());
            }
        }
        private void CommandHandlerAttack(string[] args)
        {
            try
            {
                Attack(Convert.ToInt32(args[0]));
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void CommandHandlerEquip(string[] args)
        {
            try
            {
                SwitchActiveItem(Convert.ToInt32(args[0]));
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            if(attacker.GetType() != typeof(PlayerCharacter))
                Console.WriteLine("You have been attacked by " + attacker.GetName());
            else
                Console.WriteLine("You just harmed yourself idiot");
            GetHarmed(damage);
        }
        private void CommandHandlerUseItemOnGateway(string[] args)
        {
            if(_equippedItem != null)
            {
                try
                {
                    UseEquippedItemOnGateway(Convert.ToInt32(args[0]));
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("No item equipped");
            }
        }
        private void CommandHandlerUseItemOnCharacter(string[] args)
        {
            if(_equippedItem != null)
            {
                try
                {
                    UseEquippedItemOnCharacter(Convert.ToInt32(args[0]));
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("No item equipped");
            }
        }
        private void CommandHandlerUseItem(string[] args)
        {
            if(_equippedItem != null)
            {
                UseEquippedItem();
                _isOnMove = false;
            }
            else
            {
                Console.WriteLine("No item equipped");
            }
        }
        private void CommandHandlerQuit(string[] args)
        {
            _isAlive = false;
            _isOnMove = false;
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