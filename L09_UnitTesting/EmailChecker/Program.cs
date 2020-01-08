using System;

namespace EmailChecker
{
    public class Program
    {
        static void Main(string[] args)
        {
            Test1();
            System.Threading.Thread.Sleep(10000);
        }

        public static void Test1(){
            string mailaddress = "ich@provider.com";
            if (IsEmailAddress(mailaddress))
                Console.WriteLine("TEST PASSED: " + mailaddress + " korrekt als Email-Adresse erkannt");
            else
                Console.WriteLine("TEST FAILED: " + mailaddress + " nicht als Email-Adresse erkannt, obwohl korrekt.");
        }
        public static bool IsEmailAddress(string emailAddress)
        {
            int iAt = emailAddress.IndexOf('@');
            int iDot = emailAddress.LastIndexOf('.');
            return (iAt > 0 && iDot > iAt);
        }
    }
}
