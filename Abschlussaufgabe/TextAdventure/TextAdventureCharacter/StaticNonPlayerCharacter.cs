using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public class StaticNonPlayerCharacter : NonPlayerCharacter
    {
        public StaticNonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location) 
        : base(uniqueIdentificationNumber, name, location)
        {

        }
    }
}