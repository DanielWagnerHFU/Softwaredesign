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
            if (this._equippedItem == null)
            {
                return status += " item slot [empty]|";
            }
            else
            {
                return status += " item slot [" + this._equippedItem.GetName() + "]|";
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
            if (this._healthPoints <= 0)
            {
                this._isAlive = false;
                Console.WriteLine(this._name + " died\n");
            }
        }
        protected void Attack(int characterIndex)
        {
            try
            {
                Character character = GetSupportingCharacters()[CorrectIndex(characterIndex)];
                if (character != null && character.GetIsAlive())
                {
                    character.GetAttacked(GetTotalAttackDamage(), this);
                    this._isOnMove = false;
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
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
        protected void TakeItem(int itemIndex)
        {
            if (this._inventory.Count <= this._maxInventorySlots)
            {
                try
                {
                    Item itemToTake = FindItem(CorrectIndex(itemIndex));
                    this._inventory.Add(itemToTake);
                    this._location.RemoveItem(itemToTake);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        protected void DropItem(int itemIndex)
        {
            try
            {
                Item itemToDrop = FindItem(CorrectIndex(itemIndex));
                this._location.AddItem(itemToDrop);
                this._inventory.Remove(itemToDrop);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected Character FindCharacter(string charactername)
        {
            Character character = GetSupportingCharacters().Find(_character => _character.GetName() == charactername);
            if (character == null)
                Console.WriteLine("ERROR: no such character found");
            return character;
        }
        private Item FindItem(int itemIndex)
        {
            if (itemIndex >= _location.GetItems().Count)
            {
                itemIndex = itemIndex - _location.GetItems().Count;
                return _inventory[itemIndex];
            }
            else
            {
                return _location.GetItems()[itemIndex];
            }
        }
        protected void SwitchActiveItem(int itemIndex)
        {
            try
            {
                itemIndex = CorrectIndex(itemIndex);
                Item newActiveItem = FindItem(itemIndex);
                if (this._equippedItem != null)
                {
                    this._inventory.Add(this._equippedItem);
                }
                this._equippedItem = newActiveItem;
                this._inventory.Remove(newActiveItem);
                if (this.GetType() == typeof(PlayerCharacter))
                {
                    Console.WriteLine("You equipped: " + _equippedItem.GetName());
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected void UseEquippedItem()
        {
            this._equippedItem.UseOnCharacter(this, this);
        }
        protected void UseEquippedItemOnCharacter(int characterIndex)
        {
            try
            {
                characterIndex = CorrectIndex(characterIndex);
                List<Character> characters = GetSupportingCharacters();
                this._equippedItem.UseOnCharacter(characters[characterIndex], this);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected void UseEquippedItemOnGateway(int gatewayIndex)
        {
            try
            {
                gatewayIndex = CorrectIndex(gatewayIndex);
                List<Gateway> gateways = this._location.GetGateways();
                this._equippedItem.UseOnGateway(gateways[gatewayIndex], this);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        protected void ChangeArea(int gatewayIndex)
        {
            gatewayIndex = CorrectIndex(gatewayIndex);
            try
            {
                Gateway gateway = this._location.GetGateways()[gatewayIndex];
                if (gateway != null)
                {
                    gateway.ChangeArea(this);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private Item FindItemInInventory(string itemname)
        {
            Item item = this._inventory.Find(_item => _item.GetName() == itemname);
            if (item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
        protected int CorrectIndex(int index)
        {
            return index - 1;
        }
        private Item FindItemInLocation(string itemname)
        {
            Item item = this._location.GetItems().Find(_item => _item.GetName() == itemname);
            if (item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
    }
}