using System;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public sealed class DialogNode
    {
        private double _nonPlayerMood;
        private string _nonPlayerMessage;
        private Dictionary<string, DialogNode> _playerAnswers;
        public DialogNode(double nonPlayerMood, string nonPlayerMessage, Dictionary<string, DialogNode> playerAnswers)
        {
            this._nonPlayerMood = nonPlayerMood;
            this._nonPlayerMessage = nonPlayerMessage;
            this._playerAnswers = playerAnswers;
        }
        public void ActivateDialogNode()
        {
            //TODO
        }
    }
}