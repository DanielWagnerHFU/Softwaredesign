using System;
using Xunit;
using TextAdventureCharacter;
using System.Linq;

namespace TextAdventure.Test
{
    public class UnitTest1
    {
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
            Assert.True(args.SequenceEqual(testargs));
        }
        [Fact]
        public void Test9()
        {
            Command command = new Command(new string[]{"go to"},new ParameterMethod<string>(TestDelegate),"");
            string[] args = command.GetArgs("go to china");
            string[] testargs = new string[]{"china"};
            Assert.True(args.SequenceEqual(testargs));
        }
        [Fact]
        public void Test11()
        {
            Command command = new Command(new string[]{"go to"},new ParameterMethod<string>(TestDelegate),"");
            string[] args = command.GetArgs("go to");

            bool isNull = (args.Count() == 0);
            Assert.True(isNull);
        }

        private void TestDelegate(string[] args)
        {
        }
    }
}
