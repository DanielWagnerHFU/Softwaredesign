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
            bool isEqual = command.IsEqualToCommandWithArgs("test1 2 3");
            Assert.False(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        [Fact]
        public void Test2()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            bool isEqual = command.IsEqualToCommandWithArgs("test 1 2 3");
            Assert.True(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        [Fact]
        public void Test3()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            bool isEqual = command.IsEqualToCommandWithArgs("test");
            Assert.True(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        private void TestDelegate(string[] args)
        {

        }
    }
}
