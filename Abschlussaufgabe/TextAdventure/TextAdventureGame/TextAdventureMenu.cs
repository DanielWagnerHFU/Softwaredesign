using System;
using System.Collections.Generic;
using System.IO;

namespace TextAdventureGame
{
    public sealed class TextAdventureMenu
    {
        private TextAdventureFileLoader _fileLoader;
        private TextAdventureGame _game;
        private bool _continueMenu;
        public TextAdventureMenu()
        {
            _fileLoader = null;
            _game = null;
            _continueMenu = true;
        }
        public void StartMenuLoop()
        {
            SetXmlGamepath();
            while(_continueMenu)
            {
                Console.Clear();
                ShowOptions();
                Console.Write("Option: ");
                try
                {
                    int option = Int32.Parse(Console.ReadLine());
                    Execute(option);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
            _continueMenu = false;
        }
        private void SetXmlGamepath()
        {
            try
            {
            Console.Write("Enter the xml filename: ");
            string xmlpath = Directory.GetCurrentDirectory();
            xmlpath += "/XML/";
            string fileName = Console.ReadLine();
            xmlpath += fileName + ".xml";
            _fileLoader = new TextAdventureFileLoader(xmlpath);
            _fileLoader.BuildGameObjects();
            _game = new TextAdventureGame(_fileLoader.GetCharacters());
            }
            catch(System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                SetXmlGamepath();
            }
        }
        private void StartGame()
        {
            _game.StartGameLoop();
        }
    }
}