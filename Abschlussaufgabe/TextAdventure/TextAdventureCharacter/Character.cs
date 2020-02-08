using System;
using System.Collections.Generic;
using TextAdventureItem;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public abstract class Character
    {
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
        public Character(string name, string description, double strength = 0, double healthPoints = 1, double maxHealthPoints = 1)
        {
            this.name = name;
            this.description = description;
            this.isOnMove = false;
            this.isAlive = true; 
            this.maxHealthPoints = maxHealthPoints;
            this.healthPoints = healthPoints;
            this.strength = strength;
            this.inventory = new List<Item>();
            this.location = null;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetStatusString()
        {
            return new String("[" + this.healthPoints + "/" + this.maxHealthPoints + "]");
        }
        public virtual string GetDescription()
        {
            return this.description;
        }
        public void SetLocation(Area location)
        {
            this.location = location;
        }
        public Area GetLocation()
        {
            return this.location;
        }
        public abstract void MakeAMove();
        public abstract void StartDialog(Character character);
        public virtual void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
        }
        public virtual void GetHarmed(double damage)
        {
            this.healthPoints -= damage;
            UpdateIsAlive();
        }
        protected void UpdateIsAlive()
        {
            if(this.healthPoints <= 0)
            {
                this.isAlive = false;
                Console.WriteLine(this.name + " died\n");
            }            
        }
        protected void Attack(string charactername){
            Character character = FindCharacter(charactername);
            if(character != null)
            {
               character.GetAttacked(GetTotalAttackDamage(), this);
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
            Item itemToTake = FindItemInLocation(itemname);
            if(itemToTake != null)
            {
                this.inventory.Add(itemToTake);
                this.location.RemoveItem(itemToTake);
            }
        }
        protected void DropItem(string itemname){
            Item itemToDrop = FindItemInInventory(itemname);
            if(itemToDrop != null)
            {
                this.location.AddItem(itemToDrop);
                this.inventory.Remove(itemToDrop);
            }
        }
        protected Item FindItemInInventory(string itemname)
        {
            Item item = this.inventory.Find(_item => _item.GetName() == itemname);
            if(item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
        protected Item FindItemInLocation(string itemname)
        {
            Item item = this.location.GetItems().Find(_item => _item.GetName() == itemname);
            if(item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
        protected Character FindCharacter(string charactername)
        {
            Character character = GetSupportingCharacters().Find(_character => _character.GetName() == charactername);
            if(character == null)
                Console.WriteLine("ERROR: no such character found");
            return character;
        }
        protected void SwitchActiveItem(string itemname){
            Item newActiveItem = FindItemInInventory(itemname);
            if(newActiveItem != null)
            {
                if(this.activeItem != null){
                    this.inventory.Add(this.activeItem);
                }
                this.activeItem = newActiveItem;
                this.inventory.Remove(newActiveItem);
            }
        }
        protected void UseItem()
        {
            this.activeItem.UseOnCharacter(this, this);
        }
        protected void UseItemOn(string target)
        {
            Gateway gateway = this.location.GetGateways().Find(_gateway => _gateway.GetName(this.location) == target);
            Character character = this.location.GetCharacters().Find(_character => _character.GetName() == target);
            if(gateway != null)
            {
                this.activeItem.UseOnGateway(gateway, this);
            }
            else if(character != null)
            {
                this.activeItem.UseOnCharacter(character, this);
            }
        }
        protected Gateway FindGateway(string gatewayName)
        {
            List<Gateway> gateways = this.location.GetGateways();
            Gateway gateway = gateways.Find(_gateway => _gateway.GetName(this.location) == gatewayName);
            if(gateway == null)
                Console.WriteLine("ERROR: no such gateway found");
            return gateway;
        }
        protected void ChangeArea(string gatewayName)
        {
            Gateway gateway = FindGateway(gatewayName);
            if(gateway != null)
            {
                gateway.ChangeArea(this);
            }
        }
        public void MoveToArea(Area destination)
        {
            Area location = this.location;
            destination.AddCharacter(this);
            location.RemoveCharacter(this);
        }
        public bool GetIsAlive()
        {
            return this.isAlive;
        }
        public void AddItem(Item item)
        {
            this.inventory.Add(item);
        }
        private void WriteSupportingCharacters()
        {
            List<Character> supportingCharacters = GetSupportingCharacters();
            if(supportingCharacters.Count != 0)
            {
                Console.WriteLine("Characters:");
                foreach(Character character in supportingCharacters)
                {
                    if(character.GetIsAlive())
                    {
                        Console.WriteLine("name: " + character.GetName());
                    } 
                    else 
                    {
                        Console.WriteLine("name: " + character.GetName() + " (dead)");
                    }
                }
            }
        }
    }
}