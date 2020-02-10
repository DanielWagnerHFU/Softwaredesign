using System;
using System.Collections.Generic;
using TextAdventureItem;
using TextAdventureMap;

namespace TextAdventureCharacter
{
    public abstract class Character
    {
        /*---------------------------------------
        ---------------ATTRIBUTES---------------- 
        ---------------------------------------*/
        protected string _name;
        protected string _description;
        protected bool _isOnMove;
        protected bool _isAlive;
        protected double _maxHealthPoints;
        protected double _healthPoints;
        protected double _strength;
        protected List<Item> _inventory;
        protected int _maxInventorySlots = 3;
        protected Item _equippedItem;
        protected Area _location;
        /*---------------------------------------
        ----------------METHODS------------------ 
        ---------------------------------------*/
        public Character(string name, string description, double strength = 0, double healthPoints = 1, double maxHealthPoints = 1)
        {
            this._name = name;
            this._description = description;
            this._isOnMove = false;
            this._isAlive = true; 
            this._maxHealthPoints = maxHealthPoints;
            this._healthPoints = healthPoints;
            this._strength = strength;
            this._inventory = new List<Item>();
            this._location = null;
        }
        public string GetName()
        {
            return this._name;
        }
        public string GetStatus()
        {
            String status = "|HP [" + this._healthPoints + "/" + this._maxHealthPoints + "]";
            if(this._equippedItem == null)
            {
                return status += " right hand [empty]|";
            }
            else
            {
                return status += " right hand [" + this._equippedItem.GetName() +"]|";
            }
        }
        public virtual string GetDescription()
        {
            return this._description;
        }
        public Area GetLocation()
        {
            return this._location;
        }
        public bool GetIsAlive()
        {
            return this._isAlive;
        }
        public void AddItem(Item item)
        {
            this._inventory.Add(item);
        }
        public void SetIsAlive(bool isAlive)
        {
            this._isAlive = isAlive;
        }
        public void SetIsOnMove(bool isOnMove)
        {
            this._isOnMove = isOnMove;
        }
        public void SetLocation(Area location)
        {
            this._location = location;
        }
        public abstract void MakeAMove();
        public void MoveToArea(Area destination)
        {
            Area location = this._location;
            destination.AddCharacter(this);
            location.RemoveCharacter(this);
        }
        public abstract void StartDialog(Character character);
        public virtual void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
        }
        public virtual void GetHarmed(double damage)
        {
            this._healthPoints -= damage;
            UpdateIsAlive();
        }
        protected void UpdateIsAlive()
        {
            if(this._healthPoints <= 0)
            {
                this._isAlive = false;
                Console.WriteLine(this._name + " died\n");
            }            
        }
        protected void Attack(string charactername){
            Character character = FindCharacter(charactername);
            if(character != null && character.GetIsAlive())
            {
               character.GetAttacked(GetTotalAttackDamage(), this);
               this._isOnMove = false;
            }
        }
        protected List<Character> GetSupportingCharacters()
        {
            return this._location.GetSupportingCharacters(this);
        }
        protected virtual double GetTotalAttackDamage()
        {
            return _strength;
        }
        protected void TakeItem(string itemname){
            if(this._inventory.Count <= this._maxInventorySlots)
            {
                Item itemToTake = FindItemInLocation(itemname);
                if(itemToTake != null)
                {
                    this._inventory.Add(itemToTake);
                    this._location.RemoveItem(itemToTake);
                }
            }
        }
        protected void DropItem(string itemname){
            Item itemToDrop = FindItemInInventory(itemname);
            if(itemToDrop != null)
            {
                this._location.AddItem(itemToDrop);
                this._inventory.Remove(itemToDrop);
            }
        }
        protected Character FindCharacter(string charactername)
        {
            Character character = GetSupportingCharacters().Find(_character => _character.GetName() == charactername);
            if(character == null)
                Console.WriteLine("ERROR: no such character found");
            return character;
        }
        protected bool SwitchActiveItem(string itemname){
            Item newActiveItem = FindItemInInventory(itemname);
            if(newActiveItem != null)
            {
                if(this._equippedItem != null){
                    this._inventory.Add(this._equippedItem);
                }
                this._equippedItem = newActiveItem;
                this._inventory.Remove(newActiveItem);
                return true;
            }
            return false;
        }
        protected void UseEquippedItem()
        {
            this._equippedItem.UseOnCharacter(this, this);
        }
        protected void UseEquippedItemOn(string target)
        {
            Gateway gateway = this._location.GetGateways().Find(_gateway => _gateway.GetName(this._location) == target);
            if(gateway == null)
            {
                gateway = this._location.GetGateways().Find(_gateway => Convert.ToString(_gateway.GetUIN(this._location)) == target);
            }
            Character character = this._location.GetCharacters().Find(_character => _character.GetName() == target);
            if(gateway != null)
            {
                this._equippedItem.UseOnGateway(gateway, this);
            }
            else if(character != null)
            {
                this._equippedItem.UseOnCharacter(character, this);
                this._isOnMove = false;
            }
        }
        protected void ChangeArea(string gatewayName)
        {
            Gateway gateway = FindGateway(gatewayName);
            if(gateway != null)
            {
                gateway.ChangeArea(this);
            }  
        }
        protected virtual Gateway FindGateway(string gatewayName)
        {
            List<Gateway> gateways = this._location.GetGateways();
            Gateway gateway = gateways.Find(_gateway => _gateway.GetDestinationName(this._location) == gatewayName);
            if(gateway == null)
            {
                gateway = gateways.Find(_gateway => Convert.ToString(_gateway.GetUIN(this._location)) == gatewayName);
            }
            if((gateway == null) && (this.GetType() == typeof(PlayerCharacter)))
                Console.WriteLine("ERROR: no such gateway found");
            return gateway;
        }        
        private Item FindItemInInventory(string itemname)
        {
            Item item = this._inventory.Find(_item => _item.GetName() == itemname);
            if(item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
        private Item FindItemInLocation(string itemname)
        {
            Item item = this._location.GetItems().Find(_item => _item.GetName() == itemname);
            if(item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }    
    }
}