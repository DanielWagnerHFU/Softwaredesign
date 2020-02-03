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
            foreach(string command in commands)
            {
                if(commandWithArgs.StartsWith(command))
                {
                    string args = commandWithArgs.TrimStart(command);
                    if(args[0] == ' ')
                    {
                        isEqual = true;
                    }
                    else if (args == "")
                    {
                        isEqual = true;
                    }
                }
            }
            return isEqual;
        }
        public string[] GetArgsArray(string commandWithArgs)
        {
            //TODO
            //string[] keywords = commandExpression.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            return null;
        }
        public ParameterMethod<string> GetMethodToCall()
        {
            return this.methodToCall;
        }
    }
}