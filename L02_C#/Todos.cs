using System;

namespace L02_C_
{
    class Todos
    {
        //TODO 1
        /* Wieviel bytes Speicherplatz benötigen die 
        o.a. numerischen Datentypen jeweils? */
        public String Todo_1()
        {
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
        public String Todo_2()
        {
            String text = "2 TODO - memory of the String >Hello, World<\n";
            text += "\tOne char has 2 byte -> The String has 2*12 = 24 byte + Overhead Information\n";
            return text;
        }
        //TODO 3
        /*Vergleicht den Umfang der darstellbaren Zahlen 
        zwischen int und short, sowie zwischen float und double. 
        Wie groß ist jeweils der größte und der kleinste Wert? 
        Wie groß ist der kleinste positive mit float darstellbare Wert? */
        public String Todo_3()
        {
            String text = "3 TODO - value range\n";
            text += "\tint   := {x € N | -2147483648 <= x <= 2147483647} \n";
            text += "\tshort := {x € N | -32768 <= x <= 32767} \n";
            text += "\tdouble := {x |(-1.7*10^308 <= x <= 1.7*10^308) to (-5.0*10^−324 <= x <= 5.0*10^−324)}\n";
            text += "\tfloat  := {x |(-3.4*10^38 <= x <= 3.4*10^38) to (-1.5*10^−45 <= x <= 1.5*10^−45)}\n";
            return text;
        }
        //TODO 4
        /*Was heißt Fließkommazahl und was heißt Festkommazahl? 
        Für welchen Anwendungsbereich ist decimal besonders geeignet? Warum?*/
        public String Todo_4()
        {
            String text = "4 TODO - floating point numbers and fixed point numbers\n";
            text += "\tFixed point numbers have a fixed position for the decimal point\n";
            text += "\tFloating point numbers have no fixed position for the decimal point\n";
            text += "\tInstead they save two numbers e and m (using m * 10^e = x)\n";
            text += "\tBecause the decimal type has more precision and a smaller range, \n\tit's appropriate for financial and monetary calculations.\n";
            return text;
        }
        //TODO 5
        /* Erzeugt in Visual Studio Code ein neues C#-Projekt 
        und fügt oben stehende Deklarationen und Initialisierungen 
        der Variablen i, pi, und salute ein. */
        public String Todo_5()
        {
            int i = 42;
            double pi = 3.1415;
            string salute = "Hello, World";

            String text;
            text = "5 TODO - variables (int, double, string)\n";
            text += "\ti:      " + i + "\n\tpi:     " + pi + "\n\tsalute: " + salute + "\n";
            return text;
        }
        //TODO 6
        /* Verändert die Deklarationen so, 
        dass var statt der Typen verwendet wird und überzeugt Euch, 
        dass der Compiler den Code korrekt übersetzt. */
        public String Todo_6()
        {
            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World";

            String text;
            text = "6 TODO - variables declared with var\n";
            text += "\ti:      " + i + " of Type " + i.GetType() + "\n\tpi:     " + pi + " of Type " + pi.GetType() + "\n\tsalute: " + salute + " of Type " + salute.GetType() + "\n";
            return text;
        }
        //TODO 7
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
        public String Todo_7()
        {
            var nullDouble = 0D;
            var nullFloat = 0F;
            var nullShort = (short)0;

            String text;
            text = "7 TODO - variables with var and explicit Type\n";
            text += "\tnullDouble: " + nullDouble + " of Type " + nullDouble.GetType() + "\n\tnullFloat:  " + nullFloat + " of Type " + nullFloat.GetType() + "\n\tnullShort:  " + nullShort + " of Type " + nullShort.GetType() + "\n";
            return text;
        }

        public override String ToString()
        {
            return Todo_1() + Todo_2() + Todo_3() + Todo_4() + Todo_5() + Todo_6() + Todo_7();
        }
    }
}
