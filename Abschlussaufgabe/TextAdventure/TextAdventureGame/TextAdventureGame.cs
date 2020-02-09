using System;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public sealed class TextAdventureGame
    {
        private List<Character> _characterList;
        public TextAdventureGame(List<Character> characters)
        {
            this._characterList = characters;
        }
        public void StartGameLoop()
        {
            Console.Clear();
            PlayerCharacter playerCharacter = GetPlayerCharacter();
            playerCharacter.SetIsAlive(true);
            Character characterOnMove;
            while(playerCharacter.GetIsAlive())
            {
                for(int i = 0; (i < _characterList.Count) && (playerCharacter.GetIsAlive()); i++)
                {
                    characterOnMove = _characterList[i];
                    if(characterOnMove.GetIsAlive())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|" + characterOnMove.GetName() + " on move|");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        characterOnMove.MakeAMove();
                    }
                }
            }
        }
        private PlayerCharacter GetPlayerCharacter()
        {
            PlayerCharacter playerCharacter = (PlayerCharacter)this._characterList.Find(isPlayerCharacter);
            return playerCharacter;
        }
        private bool isPlayerCharacter(Character character)
        {
            return (character.GetType() == typeof(PlayerCharacter))? true : false;
        }
    }
}