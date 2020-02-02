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
        public virtual string GetDescription()
        {
            //TODO - evtl. mehr Sinn wenn nur bei NPCs?
            return "TODO";
        }
        public abstract void MakeAMove();
        public virtual void GetHarmed(double damage)
        {
            //TODO
        }
        public void Attack(Character character){
            //TODO
        }
        protected List<Character> GetSupportingCharacters()
        {
            return this.location.GetSupportingCharacters(this);
        }
        protected virtual double GetTotalAttackDamage()
        {
            return strength;
        }
        public void TakeItem(string itemName){
            //TODO
        }
        public void DropItem(string itemName){
            //TODO
        }
        protected void UseItemOnSomeone(string itemName, string characterName)
        {
            //TODO
        }
        protected void UseItemOnYourself(string itemName)
        {
            //TODO
        }
        protected void UseItemOnGateway(string itemName, string gatewayName)
        {
            //TODO - Gateways haben noch keinen Namen - wie soll das hier genau funktionieren?
        }
    }
}