using System;
using System.Collections.Generic;
using System.IO;

namespace TextAdventureGame
{
    public sealed class TextAdventureMenu
    {
        private TextAdventureFileHandler fileLoader;
        private TextAdventureGame game;
        private bool continueMenu;
        public TextAdventureMenu()
        {
            this.fileLoader = null;
            this.game = null;
            this.continueMenu = true;
        }
        public void StartMenuLoop()
        {
            SetXmlGamepath();
            while(continueMenu)
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
            this.continueMenu = false;
        }
        private void SetXmlGamepath()
        {
            Console.Write("Enter the xml filename (without .xml): ");
            string xmlpath = Directory.GetCurrentDirectory();
            xmlpath += "/XML/";
            string fileName = Console.ReadLine();
            xmlpath += fileName + ".xml";
            this.fileLoader = new TextAdventureFileHandler(xmlpath);
            this.fileLoader.BuildGameObjects();
            this.game = new TextAdventureGame(this.fileLoader.GetCharacters());
        }
        private void StartGame()
        {
            this.game.StartGameLoop();
        }
    }
}