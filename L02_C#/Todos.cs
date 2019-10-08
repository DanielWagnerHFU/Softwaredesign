using System;

namespace L02_C_
{
    class Todos
    {
        public void Todo_1()
        {
            int i = 42;
            double pi = 3.1415;
            string salute = "Hello, World";

            Console.WriteLine("First TODO - variables (int, double, string)");
            Console.WriteLine("i: " + i + " - pi: " + pi + " - salute: " + salute + "\n");
        }
        public void Todo_2()
        {
            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World";

            Console.WriteLine("Second TODO - variables with var");
            Console.WriteLine("i: " + i + " of Type " + i.GetType() + " - pi: " + pi + " of Type " + pi.GetType() + " - salute: " + salute + " of Type " + salute.GetType() + "\n");
        }
    }
}
