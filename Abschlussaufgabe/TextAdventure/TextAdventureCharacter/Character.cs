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
            _name = name;
            _description = description;
            _isOnMove = false;
            _isAlive = true;
            _maxHealthPoints = maxHealthPoints;
            _healthPoints = healthPoints;
            _strength = strength;
            _inventory = new List<Item>();
            _location = null;
        }
        public string GetName()
        {
            return _name;
        }
        public string GetStatus()
        {
            String status = "|HP [" + _healthPoints + "/" + _maxHealthPoints + "]";
            if (_equippedItem == null)
            {
                return status += " item slot [empty]|";
            }
            else
            {
                return status += " item slot [" + _equippedItem.GetName() + "]|";
            }
        }
        public virtual string GetDescription()
        {
            return _description;
        }
        public Area GetLocation()
        {
            return _location;
        }
        public bool GetIsAlive()
        {
            return _isAlive;
        }
        public void AddItem(Item item)
        {
            _inventory.Add(item);
        }
        public void SetIsAlive(bool isAlive)
        {
            _isAlive = isAlive;
        }
        public void SetIsOnMove(bool isOnMove)
        {
            _isOnMove = isOnMove;
        }
        public void SetLocation(Area location)
        {
            _location = location;
        }
        public abstract void MakeAMove();
        public void MoveToArea(Area destination)
        {
            Area location = _location;
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
            _healthPoints -= damage;
            UpdateIsAlive();
        }
        protected virtual void UpdateIsAlive()
        {
            if (_healthPoints <= 0)
            {
                _isAlive = false;
                Console.WriteLine(_name + " died\n");
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
                    _isOnMove = false;
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected List<Character> GetSupportingCharacters()
        {
            return _location.GetSupportingCharacters(this);
        }
        protected virtual double GetTotalAttackDamage()
        {
            if (_equippedItem != null && _equippedItem.GetType() == typeof(DamageAmplifier))
            {
                DamageAmplifier damageAmplifier = (DamageAmplifier)_equippedItem;
                return _strength * damageAmplifier.GetMultiplicity();
            }
            else
            {
                return _strength;
            }
        }
        protected void TakeItem(int itemIndex)
        {
            if (_inventory.Count <= _maxInventorySlots)
            {
                try
                {
                    Item itemToTake = FindItem(CorrectIndex(itemIndex));
                    _inventory.Add(itemToTake);
                    _location.RemoveItem(itemToTake);
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
                _location.AddItem(itemToDrop);
                _inventory.Remove(itemToDrop);
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
        protected Item FindItem(int itemIndex)
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
                if (_equippedItem != null)
                {
                    if (_inventory.Count <= _maxInventorySlots)
                        _inventory.Add(_equippedItem);
                    else
                        _location.AddItem(_equippedItem);
                }
                _equippedItem = newActiveItem;
                _inventory.Remove(newActiveItem);
                _location.GetItems().Remove(newActiveItem);
                if (GetType() == typeof(PlayerCharacter))
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
            _equippedItem.UseOnCharacter(this, this);
        }
        protected void UseEquippedItemOnCharacter(int characterIndex)
        {
            try
            {
                characterIndex = CorrectIndex(characterIndex);
                List<Character> characters = GetSupportingCharacters();
                _equippedItem.UseOnCharacter(characters[characterIndex], this);
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
                List<Gateway> gateways = _location.GetGateways();
                _equippedItem.UseOnGateway(gateways[gatewayIndex], this);
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
                Gateway gateway = _location.GetGateways()[gatewayIndex];
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
            Item item = _inventory.Find(_item => _item.GetName() == itemname);
            if (item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
        protected int CorrectIndex(int index)
        {
            return index - 1;
        }
        public void GetHealed(double hpBoost)
        {
            _healthPoints += hpBoost;
            if(_healthPoints > _maxHealthPoints)
            {
                _healthPoints = _maxHealthPoints;
            }
        }
        private Item FindItemInLocation(string itemname)
        {
            Item item = _location.GetItems().Find(_item => _item.GetName() == itemname);
            if (item == null)
                Console.WriteLine("ERROR: no such item found");
            return item;
        }
    }
}