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
        protected string description;
        protected bool isOnMove;
        protected bool isAlive;
        protected double maxHealthPoints;
        protected double healthPoints;
        protected double strength;
        protected List<Item> inventory;
        protected Item activeItem;
        protected Area location;
        public Character(int uniqueIdentificationNumber, string name, string description, Area location)
        {
            this.uniqueIdentificationNumber = uniqueIdentificationNumber;
            this.name = name;
            this.description = description;
            this.isOnMove = false;
            this.isAlive = true; 
            this.maxHealthPoints = 1;
            this.healthPoints = 1;
            this.strength = 0;
            this.inventory = new List<Item>();
            this.location = location;
            this.location.AddCharacter(this);
        }
        public string GetName()
        {
            return this.name;
        }
        public virtual string GetDescription()
        {
            return this.description;
        }
        public abstract void MakeAMove();
        public abstract void StartDialog(Character character);
        public virtual void GetHarmed(double damage)
        {
            this.healthPoints -= damage;
            if(this.healthPoints <= 0)
            {
                this.isAlive = false;
            }
            //TODO Update Mood for NPC
        }
        protected void Attack(string charactername){
            Character character = FindCharacter(charactername);
            if(character != null)
            {
               character.GetHarmed(GetTotalAttackDamage());
            }
            else
            {
                Console.WriteLine("ERROR: no such character found");
            }
        }
        protected List<Character> GetSupportingCharacters()
        {
            return this.location.GetSupportingCharacters(this);
        }
        protected virtual double GetTotalAttackDamage()
        {
            return strength;
        }
        protected void TakeItem(string itemname){
            Item itemToTake = this.location.GetItems().Find(item => item.GetName() == itemname);
            if(itemToTake != null)
            {
                this.inventory.Add(itemToTake);
                this.location.RemoveItem(itemToTake);
            }
            else
            {
                Console.WriteLine("ERROR: no such item found");
            }
        }
        protected void DropItem(string itemname){
            Item itemToDrop = this.inventory.Find(item => item.GetName() == itemname);
            if(itemToDrop != null)
            {
                this.location.AddItem(itemToDrop);
                this.inventory.Remove(itemToDrop);
            }
            else
            {
                Console.WriteLine("ERROR: no such item found");
            }
        }
        protected void UseItemOnSomeone(string charactername)
        {
            Character character = FindCharacter(charactername);
            if(character != null)
            {
               this.activeItem.UseOnCharacter(character); 
            }
            else
            {
                Console.WriteLine("ERROR: no such character found");
            }
        }
        protected Character FindCharacter(string charactername)
        {
            return GetSupportingCharacters().Find(character => character.GetName() == charactername);
        }
        protected void UseItemOnYourself()
        {
            this.activeItem.UseOnCharacter(this);
        }
        protected void SwitchActiveItem(string itemname){
            Item newActiveItem = this.inventory.Find(item => item.GetName() == itemname);
            if(this.activeItem != null){
                this.inventory.Add(this.activeItem);
            }
            this.activeItem = newActiveItem;
            this.inventory.Remove(newActiveItem);
        }
        protected void UseItemOnGateway(string gatewayName)
        {
            this.activeItem.UseOnGateway(FindGateway(gatewayName));
        }
        protected Gateway FindGateway(string gatewayName)
        {
            List<Gateway> gateways = this.location.GetGateways();
            return gateways.Find(gateway => gateway.GetName(this.location) == gatewayName);
        }
        public void AddItem(Item item)
        {
            this.inventory.Add(item);
        }
    }
}