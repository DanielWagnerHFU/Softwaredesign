using System;
using System.Collections.Generic;

namespace TextAdventureCharacter
{
    public sealed class DialogNode
    {
        private double nonPlayerMood;
        private string nonPlayerMessage;
        private Dictionary<string, DialogNode> playerAnswers;
        public DialogNode(double nonPlayerMood, string nonPlayerMessage, Dictionary<string, DialogNode> playerAnswers)
        {
            this.nonPlayerMood = nonPlayerMood;
            this.nonPlayerMessage = nonPlayerMessage;
            this.playerAnswers = playerAnswers;
        }
        public void ActivateDialogNode()
        {
            //TODO
        }
    }
}