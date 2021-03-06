using System;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class DialogNode
    {
        private readonly double _moodChange;
        private readonly string _playerText;

        private readonly string _npcText;
        readonly List<DialogNode> _dialogChildren;

        public DialogNode(double moodChange, string playerText, string npcText)
        {
            _moodChange = moodChange;
            _playerText = playerText;
            _npcText = npcText;
            _dialogChildren = new List<DialogNode>();
        }

        public void AddDialogChild(DialogNode dialogNode) => _dialogChildren.Add(dialogNode);

        public string GetPlayerText() => _playerText;

        public void UseDialogNode(PlayerCharacter player, NPC talkPartner)
        {
            talkPartner.ChangeMood(player, _moodChange);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (_playerText != "")
                Console.WriteLine(player.GetName() + ": " + _playerText);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (_npcText != "")
                Console.WriteLine(talkPartner.GetName() + ": " + _npcText);
            Answers(player, talkPartner);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void InputAnswer(PlayerCharacter player, NPC talkPartner)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Type in a number for your answer: ");
            string input = Console.ReadLine();
            try
            {
                DialogNode nextDialog = _dialogChildren[Convert.ToInt32(input) - 1];
                nextDialog.UseDialogNode(player, talkPartner);
            }
            catch
            {
                Console.WriteLine("ERROR: Not a valid Answer - try again");
                UseDialogNode(player, talkPartner);
            }
        }

        private void Answers(PlayerCharacter player, NPC talkPartner)
        {
            if (_dialogChildren.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Answers: ");
                for (int i = 0; i < _dialogChildren.Count; i++)
                    Console.WriteLine("  " + (i + 1) + ": " + _dialogChildren[i].GetPlayerText());
                InputAnswer(player, talkPartner);
            }
        }

        public static DialogNode BuildFromXmlNode(XmlNode dialogNode)
        {
            XmlAttributeCollection attributes = dialogNode.Attributes;
            double moodChange = Convert.ToDouble(attributes[0].Value);
            string playerText = attributes[1].Value;
            string npcText = attributes[2].Value;
            return new DialogNode(moodChange, playerText, npcText);
        }
    }
}