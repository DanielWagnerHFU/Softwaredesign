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
            this.isAlive = true; 
            this.maxHealthPoints = 1;
            this.healthPoints = 1;
            this.strength = 0;
            this.inventory = new List<Item>();
            this.location = location;
        }
        public virtual string GetDescription()
        {
            return this.name + "\n" + this.description;
        }
        public abstract void MakeAMove();
        public virtual void GetHarmed(double damage)
        {
            this.healthPoints -= damage;
            if(this.healthPoints <= 0)
            {
                this.isAlive = false;
            }
        }
        protected void Attack(Character character){
            character.GetHarmed(GetTotalAttackDamage());
        }
        protected List<Character> GetSupportingCharacters()
        {
            return this.location.GetSupportingCharacters(this);
        }
        protected virtual double GetTotalAttackDamage()
        {
            return strength;
        }
        protected void TakeItem(int itemAreaIndex){
            Item item = this.location.FindItem(itemAreaIndex);
            this.inventory.Add(item);
            this.location.RemoveItem(item);
        }
        protected void DropItem(int itemIndex){
            Item item = this.inventory[itemIndex];
            this.location.AddItem(item);
            this.inventory.Remove(item);
        }
        protected void UseItemOnSomeone(int characterIndex)
        {
            this.activeItem.UseOnCharacter(FindCharacter(characterIndex));
        }
        protected Character FindCharacter(int characterIndex)
        {
            return this.location.GetSupportingCharacters(this)[characterIndex];
        }
        protected void UseItemOnYourself()
        {
            this.activeItem.UseOnCharacter(this);
        }
        protected void SwitchActiveItem(int itemIndex){
            Item newActiveItem = this.inventory[itemIndex];
            if(this.activeItem != null){
                this.inventory.Add(this.activeItem);
            }
            this.activeItem = newActiveItem;
            this.inventory.Remove(newActiveItem);
        }
        protected void UseItemOnGateway(int gatewayIndex)
        {
            this.activeItem.UseOnGateway(FindGateway(gatewayIndex));
        }
        protected Gateway FindGateway(int gatewayIndex)
        {
            return this.location.GetGateways()[gatewayIndex];
        }
    }
}