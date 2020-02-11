using System;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public sealed class TextAdventureGame
    {
        private readonly List<Character> _characterList;

        public TextAdventureGame(List<Character> characters)
        {
            if (characters.Count == 0)
            {
                throw new Exception("Not enough characters");
            }
            else
            {
                _characterList = characters;
            }
        }

        public void StartGameLoop()
        {
            Console.Clear();
            PlayerCharacter playerCharacter = GetPlayerCharacter();
            playerCharacter.SetIsAlive(true);
            Character characterOnMove;
            while (playerCharacter.GetIsAlive())
            {
                for (int i = 0; (i < _characterList.Count) && (playerCharacter.GetIsAlive()); i++)
                {
                    characterOnMove = _characterList[i];
                    if (characterOnMove.GetIsAlive())
                        characterOnMove.MakeAMove();
                }
            }
        }

        private PlayerCharacter GetPlayerCharacter()
        {
            PlayerCharacter playerCharacter = (PlayerCharacter)_characterList.Find(IsPlayerCharacter);
            return playerCharacter;
        }

        private bool IsPlayerCharacter(Character character) => character.GetType() == typeof(PlayerCharacter);
    }
}