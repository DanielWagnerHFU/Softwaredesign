using System;

namespace TextAdventureCharacter
{
    public delegate void ParameterMethod<T>(T[] args);
    public sealed class Command
    {
        private string[] commands;
        private ParameterMethod<string> methodToCall;
        private string description;
        private int argumentsCount;
        public Command(string[] commands, ParameterMethod<string> methodToCall, string description, int argumentsCount = 0)
        {
            this.commands = commands;
            this.methodToCall = methodToCall;
            this.description = description;
            this.argumentsCount = argumentsCount;
        }
        public string GetDescription()
        {
            return this.description;
        }
        public bool IsEqualToCommandWithArgs(string commandString)
        {
            string[] commandSplitString = commandString.Split(":", StringSplitOptions.None);
            if(Array.Exists(this.commands, command => command == commandSplitString[0].TrimEnd(' ')))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        private string GetArgsString(string commandString)
        {
            string[] commandSplitString = commandString.Split(":", StringSplitOptions.None);
            if(commandSplitString.Length == 1)
            {
                return null;
            } 
            else
            {
                return commandSplitString[1];
            }
        }
        public string[] GetArgs(string commandWithArgs)
        {
            string argsString = GetArgsString(commandWithArgs);
            return argsString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }
        public ParameterMethod<string> GetMethodToCall()
        {
            return this.methodToCall;
        }
        public int GetArgumentsCount()
        {
            return this.argumentsCount;
        }
    }
}