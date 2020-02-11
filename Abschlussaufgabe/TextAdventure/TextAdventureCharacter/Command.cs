using System;

namespace TextAdventureCharacter
{
    public delegate void ParameterMethod<T>(T[] args);

    public sealed class Command
    {
        private readonly string[] _commandList;
        private readonly ParameterMethod<string> _methodToCall;
        private readonly string _description;
        private readonly int _argumentsCount;

        public Command(string[] commands, ParameterMethod<string> methodToCall, string description, int argumentsCount = 0)
        {
            _commandList = commands;
            _methodToCall = methodToCall;
            _description = description;
            _argumentsCount = argumentsCount;
        }

        public string GetDescription()
        {
            return _description;
        }

        public bool IsEqualToCommand(string commandString)
        {
            string[] commandSplitString = commandString.Split(":", StringSplitOptions.None);
            return Array.Exists(_commandList, command => command == commandSplitString[0].TrimEnd(' '));
        }

        private string GetArgsString(string commandString)
        {
            string[] commandSplitString = commandString.Split(":", StringSplitOptions.None);
            if (commandSplitString.Length == 1)
                return "";
            else
                return commandSplitString[1];
        }

        public string[] GetArgs(string commandWithArgs)
        {
            string argsString = GetArgsString(commandWithArgs);
            return argsString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        }

        public ParameterMethod<string> GetMethodToCall()
        {
            return _methodToCall;
        }

        public int GetArgumentsCount()
        {
            return _argumentsCount;
        }
    }
}