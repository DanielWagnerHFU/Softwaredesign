using System;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public abstract class NonPlayerCharacter : Character
    {
        public NonPlayerCharacter(int uniqueIdentificationNumber, string name, Area location) 
        : base(uniqueIdentificationNumber, name, location)
        {

        }
    }
}