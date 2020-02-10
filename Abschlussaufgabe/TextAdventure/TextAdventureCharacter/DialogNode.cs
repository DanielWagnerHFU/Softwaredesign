using System;
using System.Collections.Generic;
using System.Xml;

namespace TextAdventureCharacter
{
    public sealed class DialogNode
    {
        private double _moodChange;
        private string _playerText;

        private string _npcText;
        List<DialogNode> _dialogChildren;
        public DialogNode(double moodChange, string playerText, string npcText)
        {
            _moodChange = moodChange;
            _playerText = playerText;
            _npcText = npcText;
            _dialogChildren = new List<DialogNode>();
        }
        public void AddDialogChild(DialogNode dialogNode)
        {
            _dialogChildren.Add(dialogNode);
        }
        public string GetPlayerText()
        {
            return _playerText;
        }
        public void UseDialogNode(PlayerCharacter player, NPC talkPartner)
        {
            talkPartner.ChangeMood(player, _moodChange);
            if(_playerText != "")
                Console.WriteLine(player.GetName() + ": " +_playerText);
            if(_npcText != "")
                Console.WriteLine(talkPartner.GetName() + ": " +_npcText);
            Answers(player, talkPartner);
        }
        private void Answers(PlayerCharacter player, NPC talkPartner)
        {
            if(_dialogChildren.Count != 0)
            {
                Console.WriteLine("Answers: ");
                for(int i = 0; i < _dialogChildren.Count; i++)
                {
                    Console.WriteLine("  " + (i+1) + ": " + _dialogChildren[i].GetPlayerText());
                }
                Console.Write("Type in a number for your answer: ");
                string input = Console.ReadLine();
                try
                {
                    DialogNode nextDialog = _dialogChildren[Convert.ToInt32(input)-1];
                    nextDialog.UseDialogNode(player, talkPartner);
                }
                catch
                {
                    Console.WriteLine("ERROR: Not a valid Answer - try again");
                    UseDialogNode(player, talkPartner);
                }
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