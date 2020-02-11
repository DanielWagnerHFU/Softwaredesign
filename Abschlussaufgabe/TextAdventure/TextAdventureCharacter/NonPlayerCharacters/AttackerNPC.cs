using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class AttackerNPC : NPC
    {
        protected AttackerNPC(string name, string description)
        : base(name, description)
        {
        }

        protected virtual void ManageAttackBehaviour()
        {
            Character attackTarget = GetAttackTarget();
            if (attackTarget != null)
            {
                int attackTargetIndex = GetSupportingCharacters().FindIndex(c => c == attackTarget);
                Attack(CorrectIndexPlus(attackTargetIndex));
                _isOnMove = false;
            }
        }

        protected abstract Character GetAttackTarget();
    }
}