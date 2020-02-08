using System;
using System.Collections.Generic;

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
            while(continueMenu)
            {
                Console.Clear();
                ShowOptions();
                try
                {
                    int option = Int32.Parse(Console.ReadLine());
                    Execute(option);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Not a valid option | Exception: " + e.GetType().ToString());
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
                    StartMenuLoop();
                    break;
                case 3:
                    Quit();
                    break; 
            }
        }
        private void ShowOptions()
        {
                Console.WriteLine("Type in one of the following option-numbers");
                Console.WriteLine("1: set XML gamepath");
                Console.WriteLine("2: start game");
                Console.WriteLine("3: quit");
        }
        private void Quit()
        {
            this.continueMenu = false;
        }
        private void SetXmlGamepath()
        {
            Console.Write("Enter the exact Path here: ");
            string xmlGamepath = Console.ReadLine();
            try
            {
                this.fileLoader = new TextAdventureFileHandler(xmlGamepath);
            } 
            catch (Exception e)
            {
                Console.WriteLine("Not a valid path | Exception: " + e.GetType().ToString());
            }
        }
        private void StartGame(string xmlGamepath)
        {
            this.fileLoader.BuildGameObjects();
            this.game = new TextAdventureGame(this.fileLoader.GetCharacters());
        }
    }
}