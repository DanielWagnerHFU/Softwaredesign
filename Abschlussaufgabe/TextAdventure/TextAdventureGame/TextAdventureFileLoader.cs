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
        private readonly string _filepath;
        private readonly XmlNode _xmlRootNode;
        private readonly List<Character> _characterList;

        public TextAdventureFileLoader(string filepath)
        {
            _filepath = filepath;
            _xmlRootNode = GetRootNode(filepath);
            _characterList = new List<Character>();
        }

        public string GetPath() => _filepath;

        public List<Character> GetCharacters() => _characterList;

        public void BuildGameObjects()
        {
            XmlNodeList areas = GetAreasNode();
            List<Area> areaList = BuildAreaObjects(areas);
            XmlNodeList gateways = GetGatewaysNode();
            BuildGatewayObjects(gateways, areaList);
        }

        private XmlNode GetRootNode(string filepath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filepath);
            return xmlDocument.DocumentElement;
        }

        private XmlNodeList GetAreasNode() => _xmlRootNode.SelectNodes(".//Area");

        private XmlNodeList GetGatewaysNode() => _xmlRootNode.SelectNodes(".//Gateway");

        private List<Gateway> BuildGatewayObjects(XmlNodeList gatewayNodeList, List<Area> areaList)
        {
            List<Gateway> gateways = new List<Gateway>();
            foreach (XmlNode gatewayNode in gatewayNodeList)
                gateways.Add(BuildGatewayObject(gatewayNode, areaList));
            return gateways;
        }

        private Gateway BuildGatewayObject(XmlNode gatewayNode, List<Area> areaList)
        {
            switch (gatewayNode.Attributes[0].Value)
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
            foreach (XmlNode areaNode in areaNodeList)
            {
                Area area = BuildAreaObject(areaNode);
                BuildCharactersForArea(area, areaNode);
                BuildItemsForArea(area, areaNode);
                areaList.Add(area);
            }
            return areaList;
        }

        private Area BuildAreaObject(XmlNode areaNode)
        {
            switch (areaNode.Attributes[0].Value)
            {
                case "Area":
                    return Area.BuildFromXmlNode(areaNode);
                default:
                    throw new Exception("Area build failed - No type");
            }
        }

        private void BuildItemsForArea(Area area, XmlNode areaNode)
        {
            if (areaNode != null)
            {
                XmlNodeList itemNodeList = areaNode.SelectNodes("child::Item");
                foreach (XmlNode itemNode in itemNodeList)
                {
                    area.AddItem(BuildItemObject(itemNode));
                }
            }
        }

        private Item BuildItemObject(XmlNode itemNode)
        {
            Item item;
            switch (itemNode.Attributes[0].Value)
            {
                case "Key":
                    item = Key.BuildFromXmlNode(itemNode); break;
                case "Text":
                    item = Text.BuildFromXmlNode(itemNode); break;
                case "Potion":
                    item = Potion.BuildFromXmlNode(itemNode); break;
                case "DamageAmplifier":
                    item = DamageAmplifier.BuildFromXmlNode(itemNode); break;
                default:
                    throw new Exception("Item build failed - No type");
            }
            ItemAddSpawnItems(item, itemNode);
            return item;
        }

        private void ItemAddSpawnItems(Item item, XmlNode itemNode)
        {
            XmlNodeList itemNodes = itemNode.SelectNodes("child::*");
            foreach (XmlNode itemN in itemNodes)
                item.AddSpawnItem(BuildItemObject(itemN));
        }

        private void BuildCharactersForArea(Area area, XmlNode areaNode)
        {
            if (areaNode != null)
            {
                XmlNodeList characterNodeList = areaNode.SelectNodes("child::Character");
                foreach (XmlNode characterNode in characterNodeList)
                {
                    Character character = BuildCharacterObject(characterNode);
                    BuildItemsForCharacter(character, characterNode);
                    area.AddCharacter(character);
                    _characterList.Add(character);
                }
            }
        }

        private Character BuildCharacterObject(XmlNode characterNode)
        {
            switch (characterNode.Attributes[0].Value)
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
            switch (characterNode.Attributes[0].Value)
            {
                case "HumanNPC":
                    character = HumanNPC.BuildFromXmlNode(characterNode); break;
                case "MonsterNPC":
                    character = MonsterNPC.BuildFromXmlNode(characterNode); break;
                case "PassivDialogNPC":
                    character = PassivDialogNPC.BuildFromXmlNode(characterNode); break;
                default:
                    throw new Exception("Character build failed - No type");
            }
            XmlNode dialogNode = characterNode.SelectSingleNode("child::*");
            if (dialogNode != null)
                character.AddDialogNode(BuildDialogNodeObject(dialogNode));
            return character;
        }

        private DialogNode BuildDialogNodeObject(XmlNode dialogNode)
        {
            DialogNode dialog = DialogNode.BuildFromXmlNode(dialogNode);
            XmlNodeList dialogNodes = dialogNode.SelectNodes("child::DialogNode");
            foreach (XmlNode xmlDialogNode in dialogNodes)
                dialog.AddDialogChild(BuildDialogNodeObject(xmlDialogNode));
            return dialog;
        }

        private void BuildItemsForCharacter(Character character, XmlNode itemsNode)
        {
            if (itemsNode != null)
            {
                XmlNodeList itemNodeList = itemsNode.SelectNodes("child::Item");
                foreach (XmlNode itemNode in itemNodeList)
                    character.AddItem(BuildItemObject(itemNode));
            }
        }
    }
}