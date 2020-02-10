using System;
using System.Collections.Generic;
using TextAdventureCharacter;
using TextAdventureMap;
using TextAdventureItem;
using System.Xml;

namespace TextAdventureGame
{
    public sealed class TextAdventureFileLoader
    {
        private string _filepath;
        private XmlNode _xmlRootNode;
        private List<Character> _characterList;
        public TextAdventureFileLoader(string filepath)
        {
            _filepath = filepath;
            _xmlRootNode = GetRootNode(filepath);
            _characterList = new List<Character>();
        }
        public List<Character> GetCharacters()
        {
            return _characterList;
        }        
        public void BuildGameObjects()
        {
            XmlNode areasNode = GetAreasNode();
            List<Area> areaList = BuildAreaObjects(areasNode.SelectNodes(".//Area"));
            XmlNode gatewaysNode = GetGatewaysNode();
            List<Gateway> gatewayList = BuildGatewayObjects(gatewaysNode.SelectNodes(".//Gateway"), areaList);
        }
        private XmlNode GetRootNode(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            return xmlDocument.DocumentElement;
        }
        private XmlNode GetAreasNode()
        {
            return _xmlRootNode.SelectSingleNode(".//Areas");
        }
        private XmlNode GetGatewaysNode()
        {
            return _xmlRootNode.SelectSingleNode(".//Gateways");
        }
        private List<Gateway> BuildGatewayObjects(XmlNodeList gatewayNodeList, List<Area> areaList)
        {
            List<Gateway> gateways = new List<Gateway>();
            foreach(XmlNode gatewayNode in gatewayNodeList)
            {
                gateways.Add(BuildGatewayObject(gatewayNode, areaList));
            }
            return gateways;
        }
        private Gateway BuildGatewayObject(XmlNode gatewayNode, List<Area> areaList)
        {
            switch(gatewayNode.Attributes[0].Value)
            {
                case "Gateway":
                    return Gateway.BuildFromXmlNode(gatewayNode, areaList);
                case "Door":
                    return Door.BuildFromXmlNode(gatewayNode, areaList);
                case "Spawner":
                    return Spawner.BuildFromXmlNode(gatewayNode, areaList, _characterList);
                case "Portal":
                    return Portal.BuildFromXmlNode(gatewayNode, areaList);
                default:
                    throw new Exception("Gateway build failed - No type");
            }
        }
        private List<Area> BuildAreaObjects(XmlNodeList areaNodeList)
        {
            List<Area> areaList = new List<Area>();
            foreach(XmlNode areaNode in areaNodeList)
            {
                Area area = BuildAreaObject(areaNode);
                BuildCharactersForArea(area, areaNode.SelectSingleNode(".//Characters"));
                BuildItemsForArea(area, areaNode.SelectSingleNode("./Items"));
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
                XmlNodeList itemNodeList = itemsNode.SelectNodes(".//Item");
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
                case "Text":
                    return Text.BuildFromXmlNode(itemNode);
                case "Potion":
                    return Potion.BuildFromXmlNode(itemNode);
                case "DamageAmplifier":
                    return DamageAmplifier.BuildFromXmlNode(itemNode);
                default:
                    throw new Exception("Item build failed - No type");
            }
        }
        private void BuildCharactersForArea(Area area, XmlNode charactersNode)
        {
            if(charactersNode != null)
            {
                XmlNodeList characterNodeList = charactersNode.SelectNodes(".//Character");
                foreach(XmlNode characterNode in characterNodeList)
                {
                    Character character = BuildCharacterObject(characterNode);
                    XmlNode itemsNode = characterNode.SelectSingleNode(".//Inventory");
                    BuildItemsForCharacter(character, itemsNode);
                    area.AddCharacter(character);
                    _characterList.Add(character);
                }
            }
        }
        private Character BuildCharacterObject(XmlNode characterNode)
        {
            switch(characterNode.Attributes[0].Value)
            {
                case "Player":
                    return PlayerCharacter.BuildFromXmlNode(characterNode);
                default:
                    return BuildNPCObjectWithDialogNodes(characterNode);
            }
        }
        private NPC BuildNPCObjectWithDialogNodes(XmlNode characterNode)
        {
            NPC character;
            switch(characterNode.Attributes[0].Value)
            {
                case "HumanNPC":
                    character = HumanNPC.BuildFromXmlNode(characterNode);
                    break;
                case "MonsterNPC":
                    character = MonsterNPC.BuildFromXmlNode(characterNode);
                    break;
                default:
                    throw new Exception("Character build failed - No type");
            }
            XmlNode dialogNode = characterNode.SelectSingleNode("child::*");
            if(dialogNode != null)
                character.AddDialogNode(BuildDialogNodeObject(dialogNode));
            return character;
        }
        private DialogNode BuildDialogNodeObject(XmlNode dialogNode)
        {
            DialogNode dialog = DialogNode.BuildFromXmlNode(dialogNode);
            XmlNodeList dialogNodes = dialogNode.SelectNodes("child::*");
            foreach(XmlNode xmlDialogNode in dialogNodes)
            {
                dialog.AddDialogChild(BuildDialogNodeObject(xmlDialogNode));
            }
            return dialog;
        }
        private void BuildItemsForCharacter(Character character, XmlNode itemsNode)
        {
            if(itemsNode != null)
            {
                XmlNodeList itemNodeList = itemsNode.SelectNodes(".//Item");
                foreach(XmlNode itemNode in itemNodeList)
                {
                    character.AddItem(BuildItemObject(itemNode));
                }
            }
        }
    }
}