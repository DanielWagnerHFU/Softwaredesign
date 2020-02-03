using System;
using Xunit;
using TextAdventureCharacter;

namespace TextAdventure.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");

        }
        private void TestDelegate(string[] args)
        {

        }
    }
}
