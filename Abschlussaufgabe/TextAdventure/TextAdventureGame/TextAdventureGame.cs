using System;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureGame
{
    public sealed class TextAdventureGame
    {
        private List<Character> characters;
        public TextAdventureGame(string filepath)
        {
            TextAdventureFileHandler fileHandler = new TextAdventureFileHandler(filepath);
            fileHandler.BuildGameObjects();
            this.characters = fileHandler.GetCharacters();
        }
        public TextAdventureGame(List<Character> characters)
        {
            //testconstructor
            this.characters = characters;
        }
        public void StartGameLoop()
        {
            PlayerCharacter playerCharacter = GetPlayerCharacter();
            Character characterOnMove;
            while(playerCharacter.GetIsAlive())
            {
                for(int i = 0; (i < characters.Count) && (playerCharacter.GetIsAlive()); i++)
                {
                    characterOnMove = characters[i];
                    if(characterOnMove.GetIsAlive())
                    {
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