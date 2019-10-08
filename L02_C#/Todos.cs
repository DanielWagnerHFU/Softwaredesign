using System;

namespace L02_C_
{
    class Todos
    {
        //TODO 1
        /* Wieviel bytes Speicherplatz benötigen die 
        o.a. numerischen Datentypen jeweils? */
        public String Todo_1(){
            String text = "1 TODO - memory of numeric datatypes\n";
            text += "\tbyte  = 1byte = 8bit\n";
            text += "\tshort = 2byte = 16bit\n";
            text += "\tint   = 4byte = 32bit\n";
            text += "\tlong  = 8byte = 64bit\n\n";
            text += "\tfloat   = 4byte  = 32bit\n";
            text += "\tdouble  = 8byte  = 64bit\n";
            text += "\tdecimal = 16byte = 128bit\n";
            return text;
        }
        //TODO 2
        /* Wieviel Speicherplatz in bytes benötigt 
        die Zeichenkette "Hello, World" ? */
        public String Todo_2(){
            String text = "2 TODO - memory of the String >Hello, World<\n";
            text += "\tOne char has 2 byte -> The String has 2*12 = 24 byte + Overhead Information\n";
            return text;
        }
        //TODO 3
        /*Vergleicht den Umfang der darstellbaren Zahlen 
        zwischen int und short, sowie zwischen float und double. 
        Wie groß ist jeweils der größte und der kleinste Wert? 
        Wie groß ist der kleinste positive mit float darstellbare Wert? */
        public String Todo_3(){
            String text = "3 TODO - value range<\n";
            text += "\tOne char has 2 byte -> The String has 2*12 = 24 byte + Overhead Information\n";
            return text;
        }
        //TODO 1
        /* Erzeugt in Visual Studio Code ein neues C#-Projekt 
        und fügt oben stehende Deklarationen und Initialisierungen 
        der Variablen i, pi, und salute ein. */
        public void Todo_a()
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
        public void Todo_b()
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
        public void Todo_c()
        {
            var var_1 = 0D;
            var var_2 = 0F;
            var var_3 = (short)0;

            Console.WriteLine("3 TODO - variables with var and explicit Type");
            Console.WriteLine("var_1: " + var_1 + " of Type " + var_1.GetType() + " - var_2: " + var_2 + " of Type " + var_2.GetType() + " - var_3: " + var_3 + " of Type " + var_3.GetType() + "\n");
        }
        
    }
}
