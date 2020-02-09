using System;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public sealed class TextAdventureGame
    {
        private List<Character> characters;
        public TextAdventureGame(List<Character> characters)
        {
            this.characters = characters;
        }
        public void StartGameLoop()
        {
            Console.Clear();
            PlayerCharacter playerCharacter = GetPlayerCharacter();
            playerCharacter.SetIsAlive(true);
            Character characterOnMove;
            while(playerCharacter.GetIsAlive())
            {
                for(int i = 0; (i < characters.Count) && (playerCharacter.GetIsAlive()); i++)
                {
                    characterOnMove = characters[i];
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
            PlayerCharacter playerCharacter = (PlayerCharacter)this.characters.Find(isPlayerCharacter);
            return playerCharacter;
        }
        private bool isPlayerCharacter(Character character)
        {
            return (character.GetType() == typeof(PlayerCharacter))? true : false;
        }
    }
}