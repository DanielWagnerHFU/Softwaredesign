using System;
using System.Collections.Generic;
using System.IO;

namespace TextAdventureGame
{
    public sealed class TextAdventureMenu
    {
        private TextAdventureFileHandler _fileLoader;
        private TextAdventureGame _game;
        private bool _continueMenu;
        public TextAdventureMenu()
        {
            this._fileLoader = null;
            this._game = null;
            this._continueMenu = true;
        }
        public void StartMenuLoop()
        {
            SetXmlGamepath();
            while(_continueMenu)
            {
                Console.Clear();
                ShowOptions();
                Console.Write("Option: ");
                int option = Int32.Parse(Console.ReadLine());
                Execute(option);
            }
        }
        private void Execute(int option)
        {
            switch(option)
            {
                case 1:
                    SetXmlGamepath();
                    break;
                case 2:
                    StartGame();
                    break;
                case 3:
                    Quit();
                    break; 
            }
        }
        private void ShowOptions()
        {
                Console.WriteLine("Type in one of the following option-numbers");
                Console.WriteLine("1: change XML gamepath");
                Console.WriteLine("2: start game");
                Console.WriteLine("3: quit");
        }
        private void Quit()
        {
            this._continueMenu = false;
        }
        private void SetXmlGamepath()
        {
            Console.Write("Enter the xml filename (without .xml): ");
            string xmlpath = Directory.GetCurrentDirectory();
            xmlpath += "/XML/";
            string fileName = Console.ReadLine();
            xmlpath += fileName + ".xml";
            this._fileLoader = new TextAdventureFileHandler(xmlpath);
            this._fileLoader.BuildGameObjects();
            this._game = new TextAdventureGame(this._fileLoader.GetCharacters());
        }
        private void StartGame()
        {
            this._game.StartGameLoop();
        }
    }
}