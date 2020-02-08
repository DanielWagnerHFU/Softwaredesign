using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using TextAdventureMap;
using TextAdventureItem;
using System.Xml;

namespace TextAdventureGame
{
    public class TextAdventureFileHandler
    {
        private string filepath;
        private XmlNode xmlRootNode;
        public TextAdventureFileHandler(string filepath)
        {
            this.filepath = filepath;
            this.xmlRootNode = GetRootNode(filepath);
        }
        private XmlNode GetAreasNode()
        {
            return this.xmlRootNode.SelectSingleNode("//Areas");
        }
        private XmlNode GetGatewaysNode()
        {
            return xmlRootNode.SelectSingleNode("//Gateways");
        }

        private void BuildGameObjects()
        {
            XmlNode areasNode = GetAreasNode();
            List<Area> areaList = BuildAreaObjects(areasNode.SelectNodes("//Area"));
            XmlNode gatewaysNode = GetGatewaysNode();
            List<Gateway> gatewayList = BuildGatewayObjects(gatewaysNode.SelectNodes("//Gateways"));
        }
        private List<Gateway> BuildGatewayObjects(XmlNodeList gatewayNodeList)
        {
            return null;
            //TODO
            //CONNECT GATEWAYS WITH AREAS BASED ON UIN
        }
        private List<Area> BuildAreaObjects(XmlNodeList areaNodeList)
        {
            List<Area> areaList = new List<Area>();
            foreach(XmlNode areaNode in areaNodeList)
            {
                Area area = BuildAreaObject(areaNode);
                BuildCharactersForArea(area, areaNode.SelectSingleNode("//Characters"));
                BuildItemsForArea(area, areaNode.SelectSingleNode("//Items"));
                areaList.Add(area);
            }
            return areaList;
        }
        private Area BuildAreaObject(XmlNode areaNode)
        {
            switch(areaNode.Attributes[0].Value)
            {
                case "Area":
                    return Area.BuildFromXmlNode(areaNode);
                default:
                    throw new Exception("Area build failed - No type");
            }
        }
        private void BuildItemsForArea(Area area, XmlNode itemsNode)
        {
            if(itemsNode != null)
            {
                XmlNodeList itemNodeList = itemsNode.SelectNodes("//Item");
                foreach(XmlNode itemNode in itemNodeList)
                {
                    area.AddItem(BuildItemObject(itemNode));
                }
            }
        }
        private Item BuildItemObject(XmlNode itemNode)
        {
            switch(itemNode.Attributes[0].Value)
            {
                case "Key":
                    return Key.BuildFromXmlNode(itemNode);
                default:
                    throw new Exception("Item build failed - No type");
            }
        }
        private void BuildCharactersForArea(Area area, XmlNode charactersNode)
        {
            if(charactersNode != null)
            {
                XmlNodeList characterNodeList = charactersNode.SelectNodes("//Character");
                foreach(XmlNode characterNode in characterNodeList)
                {
                    area.AddCharacter(BuildCharacterObject(characterNode));
                }
            }
        }
        private Character BuildCharacterObject(XmlNode characterNode)
        {
            switch(characterNode.Attributes[0].Value)
            {
                // case "Player":
                //     return PlayerCharacter.BuildFromXmlNode(characterNode);
                // case "HumanNPC":
                //     return PlayerCharacter.BuildFromXmlNode(characterNode);            
                default:
                    throw new Exception("Character build failed - No type");
            }
        }
        private void BuildItemsForCharacter(Character character, XmlNode itemsNode)
        {
            //TODO
        }
        private List<Item> BuildItemObjects(XmlNodeList itemNodeList)
        {
            return null;
            //TODO
        }
        private List<Character> BuildCharacterObjects(XmlNodeList characterNodeList)
        {
            return null;
            //TODO;
        }
        private XmlNode GetRootNode(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            return xmlDocument.DocumentElement;
        }
        public List<Character> GetCharacters()
        {
            return null;
            //TODO
        }
    }
}