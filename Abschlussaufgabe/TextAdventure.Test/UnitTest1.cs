using System;
using Xunit;
using TextAdventureCharacter;
using System.Linq;

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
        [Fact]
        public void Test4()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            bool isEqual = command.IsEqualToCommandWithArgs("te");
            Assert.False(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        [Fact]
        public void Test5()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            bool isEqual = command.IsEqualToCommandWithArgs("te st");
            Assert.False(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        [Fact]
        public void Test6()
        {
            Command command = new Command(new string[]{"te"},new ParameterMethod<string>(TestDelegate),"");
            bool isEqual = command.IsEqualToCommandWithArgs("test");
            Assert.False(isEqual, "Fehler beim Vergleich der Befehle mit und ohne Argumente");
        }
        [Fact]
        public void Test7()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            string[] args = command.GetArgs("test 1 2 ab 3");
            string[] testargs = {"1","2","ab","3"};
            Assert.True(args.SequenceEqual(testargs), testargs[0]+args[0]+" "+testargs[1]+args[1]+" "+testargs[2]+args[2]+" "+testargs[3]+args[3]+" ");
        }
        [Fact]
        public void Test8()
        {
            Command command = new Command(new string[]{"test"},new ParameterMethod<string>(TestDelegate),"");
            string[] args = command.GetArgs("test");
            string[] testargs = new string[0];
            Assert.True(args.SequenceEqual(testargs), testargs[0]+args[0]+" "+testargs[1]+args[1]+" "+testargs[2]+args[2]+" "+testargs[3]+args[3]+" ");
        }
        private void TestDelegate(string[] args)
        {

        }
    }
}
