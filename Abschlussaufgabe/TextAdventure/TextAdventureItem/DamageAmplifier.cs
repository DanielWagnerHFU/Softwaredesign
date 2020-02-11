using System;
using TextAdventureCharacter;
using TextAdventureMap;
using System.Xml;

namespace TextAdventureItem
{
    public sealed class DamageAmplifier : Item
    {
        private readonly double _multiplicity;

        public DamageAmplifier(string name, string description, double multiplicity)
        : base(name, description)
        {
            _multiplicity = multiplicity;
        }

        public double GetMultiplicity()
        {
            return _multiplicity;
        }

        public static DamageAmplifier BuildFromXmlNode(XmlNode itemNode)
        {
            XmlAttributeCollection attributes = itemNode.Attributes;
            string name = attributes[1].Value;
            string description = attributes[2].Value;
            double multiplicity = Convert.ToDouble(attributes[3].Value);
            return new DamageAmplifier(name, description, multiplicity);
        }
    }
}