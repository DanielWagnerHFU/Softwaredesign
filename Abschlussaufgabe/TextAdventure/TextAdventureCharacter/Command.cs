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
        public bool IsEqualToCommandWithArgs(string commandWithArgs)
        {
            bool isEqual = false;
            string args = GetArgsString(commandWithArgs);
            if(args != null)
                {
                if(args == "")
                {
                    isEqual = true;
                }
                else if (args[0] == ' ')
                {
                    isEqual = true;
                }
            }
            return isEqual;
        }
        private string GetArgsString(string commandWithArgs)
        {
            string args = null;
            foreach(string command in commands)
            {
                if(commandWithArgs.StartsWith(command))
                {
                    args = commandWithArgs.TrimStart(command);
                    break; 
                }
            }
            return args;   
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