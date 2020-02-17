using System;
using TextAdventureItem;
using System.Xml;
using TextAdventureMap;
using TextAdventureCharacter;
using System.Collections.Generic;

namespace TextAdventureMap
{
    public class Spawner : Gateway
    {
        private readonly List<Character> _characters;

        public Spawner(Area areaA, Area areaB, List<Character> characters)
        : base(areaA, areaB)
        {
            _characters = characters;
        }

        public override void ChangeArea(Character character)
        {
            Area destination = GetDestination(character.GetLocation());
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            for(int i = 0; i <= randomNumber; i++)
            {
                Character toSpawn = new MonsterNPC("Monster", "A Monster which will attack anyone! Be aware.");
                destination.AddCharacter(toSpawn);
                _characters.Add(toSpawn);
            }
            character.MoveToArea(destination);
            character.SetIsOnMove(false);
        }

        public static Spawner BuildFromXmlNode(XmlNode gatewayNode, List<Area> areaList, List<Character> characters){
            XmlAttributeCollection attributes = gatewayNode.Attributes;
            int uinAreaA = Int32.Parse(attributes[1].Value);
            int uinAreaB = Int32.Parse(attributes[2].Value);
            Area areaA = areaList.Find(area => area.GetUIN() == uinAreaA);
            Area areaB = areaList.Find(area => area.GetUIN() == uinAreaB);
            return new Spawner(areaA, areaB, characters);
        }
    }
}