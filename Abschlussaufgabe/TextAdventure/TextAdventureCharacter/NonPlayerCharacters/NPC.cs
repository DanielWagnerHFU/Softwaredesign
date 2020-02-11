using System;
using TextAdventureMap;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public abstract class NPC : Character
    {
        protected DialogNode _dialog;
        protected double _attackMoodChange = -100;
        protected double _moodAgressionThreshold = -10;
        protected Dictionary<Character, double> _moodAboutCharacters;

        protected NPC(string name, string description)
        : base(name, description)
        {
            _moodAboutCharacters = new Dictionary<Character, double>();
        }

        public override void GetAttacked(double damage, Character attacker)
        {
            GetHarmed(damage);
            ChangeMood(attacker, -100);
        }

        public void ChangeMood(Character character, double moodChange)
        {
            if (_moodAboutCharacters.ContainsKey(character))
                _moodAboutCharacters[character] += moodChange;
            else
                _moodAboutCharacters.Add(character, moodChange);
        }

        protected virtual void ManageRoamingBehaviour(int changeProbability)
        {
            List<Gateway> gateways = _location.GetGateways();
            if (gateways.Count != 0)
            {
                Random random = new Random();
                if (random.Next(1, 101) <= changeProbability)
                {
                    int gatewayIndex = random.Next(gateways.Count);
                    ChangeArea(CorrectIndexPlus(gatewayIndex));
                }
            }
        }

        protected int CorrectIndexPlus(int index) => index + 1;

        public void AddDialogNode(DialogNode dialogNode) => _dialog = dialogNode;

        public override void StartDialog(Character character)
        {
            if (_dialog != null)
            {
                _dialog.UseDialogNode((PlayerCharacter)character, this);
                Console.ReadKey(false);
            }
            else
            {
                Console.WriteLine("This character cannot talk");
            }
        }
    }
}