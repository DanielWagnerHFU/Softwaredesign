using System;

namespace L02_C_
{
    class Todos
    {
        //TODO 1
        /* Wieviel bytes Speicherplatz benötigen die 
        o.a. numerischen Datentypen jeweils? */
        

        //TODO 1
        /* Erzeugt in Visual Studio Code ein neues C#-Projekt 
        und fügt oben stehende Deklarationen und Initialisierungen 
        der Variablen i, pi, und salute ein. */
        public void Todo_1()
        {
            int i = 42;
            double pi = 3.1415;
            string salute = "Hello, World";

            Console.WriteLine("1 TODO - variables (int, double, string)");
            Console.WriteLine("i: " + i + " - pi: " + pi + " - salute: " + salute + "\n");
        }
        //TODO 2
        /* Verändert die Deklarationen so, 
        dass var statt der Typen verwendet wird und überzeugt Euch, 
        dass der Compiler den Code korrekt übersetzt. */
        public void Todo_2()
        {
            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World";

            Console.WriteLine("2 TODO - variables with var");
            Console.WriteLine("i: " + i + " of Type " + i.GetType() + " - pi: " + pi + " of Type " + pi.GetType() + " - salute: " + salute + " of Type " + salute.GetType() + "\n");
        }
        //TODO 3
        /* Mit der Deklaration/Initialisierung var variable = 0; 
        wird variable durch Typ Inferenz zu einer int-Variablen. 
        Wie muss die Initialisierung lauten, 
        um den Typ der Variablen zu double, 
        float oder short zu ändern, 
        ohne dass der konkrete Typ statt var hingeschrieben wird 
        (var soll stehen bleiben)? TIPP: 
        Seht Euch o.A. Referenzdokumentation zu den eingebauten Datentypen an 
        und lest Euch durch, wie zu den jeweiligen Typen die Konstanten 
        (englisch Literals) gebildet werden: 
        Was unterscheidet eine int-Konstante von einer double-Konstanten? */
        public void Todo_3()
        {
            var var_1 = 0D;
            var var_2 = 0F;
            var var_3 = (short)0;

            Console.WriteLine("3 TODO - variables with var and explicit Type");
            Console.WriteLine("var_1: " + var_1 + " of Type " + var_1.GetType() + " - var_2: " + var_2 + " of Type " + var_2.GetType() + " - var_3: " + var_3 + " of Type " + var_3.GetType() + "\n");
        }
        
    }
}
