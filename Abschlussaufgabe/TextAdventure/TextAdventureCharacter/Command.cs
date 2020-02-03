using System;

namespace TextAdventureCharacter
{
    public delegate void ParameterMethod<T>(params T[] args);
    public sealed class Command
    {
        public ParameterMethod<string> methodToCall;
        public string description;
        public Command(ParameterMethod<string> methodToCall, string description)
        {
            this.methodToCall = methodToCall;
            this.description = description;
        }
    }
}