using System;
using System.Collections.Generic;
using TextAdventureItem;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public abstract class Character
    {
        protected int uniqueIdentificationNumber;
        protected string name;
        protected bool isAlive;
        protected double maxHealthPoints;
        protected double healthPoints;
        protected double strength;
        protected List<Item> inventory;
        protected Area location;
        public Character(int uniqueIdentificationNumber, string name, Area location)
        {
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
            this.name = name;
            this.isAlive = true; 
            this.maxHealthPoints = 0;
            this.healthPoints = 0;
            this.strength = 0;
            this.inventory = new List<Item>();
            this.location = location;
        }
    }
}