using System;
using Xunit;

namespace EmailChecker.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string mailaddress = "ich@provider.com";
            bool result = EmailChecker.Program.IsEmailAddress(mailaddress);
            Assert.True(result, mailaddress + " nicht als Email-Adresse erkannt, obwohl korrekt.");
        }
    }
}
