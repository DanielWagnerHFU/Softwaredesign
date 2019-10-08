using System;

namespace L02_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Obj1 obj = new Obj1();
            Console.WriteLine(obj.salute);
            int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};
            int ergebnis = ia[2] * ia[8] + ia[4];
            Console.WriteLine(ergebnis);
        }
    }
}
