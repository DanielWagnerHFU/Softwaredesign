using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class AttackerNPC : NPC
    {
        public AttackerNPC(string name, string description) 
        : base(name, description)
        {
        }
        protected virtual void ManageAttackBehaviour()
        {
            Character attackTarget = GetAttackTarget();
            if(attackTarget != null)
            {
                    Attack(attackTarget.GetName());
                    this._isOnMove = false;
            }
        }
        protected abstract Character GetAttackTarget();

    }
}