using System;

namespace TextAdventureCharacter
{
    public delegate void ParameterMethod<T>(T[] args);
    public sealed class Command
    {
        private string[] commands;
        private ParameterMethod<string> methodToCall;
        private string description;
        public Command(string[] commands, ParameterMethod<string> methodToCall, string description)
        {
            this.commands = commands;
            this.methodToCall = methodToCall;
            this.description = description;
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
                }
            }
            return args;   
        }
        public string[] GetArgs(string commandWithArgs)
        {
            string argsString = GetArgsString(commandWithArgs);
            string[] args = argsString.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            return args;
        }
        public ParameterMethod<string> GetMethodToCall()
        {
            return this.methodToCall;
        }
    }
}