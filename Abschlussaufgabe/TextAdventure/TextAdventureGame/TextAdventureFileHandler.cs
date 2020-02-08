using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using System.Xml;
using TextAdventureMap;

namespace TextAdventureGame
{
    public class TextAdventureFileHandler
    {
        protected List<Character> characterList;
        protected XmlNode root;
        public TextAdventureFileHandler(string filepath)
        {
            SetRoot(filepath);
            BuildGameObjects();
        }
        private XmlNode GetAreasNode()
        {
            return root.SelectSingleNode("//Areas");
        }
        private XmlNode GetGatewaysNode()
        {
            return root.SelectSingleNode("//Gateways");
        }

        private void BuildGameObjects()
        {
            XmlNode areas = GetAreasNode();
            List<Area> areaList = BuildAreaObjects(areas.SelectNodes("//Area"));
            XmlNode Gateways = GetGatewaysNode();
        }
        private List<Area> BuildAreaObjects(XmlNodeList areaNodeList)
        {
            List<Area> areaList = new List<Area>();
            foreach(XmlNode areaNode in areaNodeList)
            {
                areaList.Add(BuildAreaObject(areaNode));
            }
            return areaList;
        }
        private Area BuildAreaObject(XmlNode areaNode)
        {
            switch(areaNode.Attributes[0].Value)
            {
                case "Area":
                    return Area.BuildAreaObject(areaNode);
                default:
                    return null;
            }
            //TODO weitere Areas anfügen
        }
        private void SetRoot(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            this.root = xmlDocument.DocumentElement;
        }
        public List<Character> GetCharacters()
        {
            return this.characterList;
        }
    }
}