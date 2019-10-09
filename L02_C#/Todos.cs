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
        //TODO 8
        /* Im o.a. Code-Schnipsel werden drei 
        Array-Variablen deklariert und initialisiert. 
        Wie heißen die Variablen, was ist der jeweilige Grund-Typ 
        und wieviel Speicherplätze sind jeweils reserviert worden? */
        public String Todo_8()
        {
            int[] ia = new int[10];
            char[] ca = new char[30];
            double[] da = new double[12];
            String text = "8 TODO - arrays and memory\n";
            text += "\tAll Arrays have Refereces - depending on the System 4 or 8 bytes for each element\n";
            text += "\tOn a 64 bit System:\n";
            text += "\tint[10]    - memory is 10*(4byte+8byte)  = 120byte\n";
            text += "\tchar[30]   - memory is 30*(2byte+8byte)  = 300byte\n";
            text += "\tdouble[12] - memory is 12*(16byte+8byte) = 288byte\n";
            return text;
        }
        //TODO 9
        /*Was steht in der Variablen ergebnis?*/
        public String Todo_9()
        {
            int[] ia = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
            int ergebnis = ia[2] * ia[8] + ia[4];
            String text = "9 TODO - calculating with arrays\n";
            text += "\tint[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};\n\tint ergebnis = ia[2] * ia[8] + ia[4];\n";
            text += "\tergebnis = " + ergebnis + "\n";
            return text;
        }
        //TODO 10
        /*Erzeugt einen Array vom Grund-Typ double, 
        der drei Speicherplätze enthält in denen 
        in der angegebenen Reihenfolge die Zahl PI, 
        die Eulersche Zahl und die Kepler-Konstante enthalten sind.*/
        public String Todo_10()
        {
            double[] constants = { 3.14159265359, 2.71828182846, 2.97 * Math.Pow(10, -19) };
            String text = "10 TODO - Array of pi, e and C\n";
            text += "\tpi = " + constants[0] + "\n";
            text += "\te = " + constants[1] + "\n";
            text += "\tC = " + constants[2] + "\n";
            return text;
        }
        //TODO 11
        /* Gebt nach der Initialisierung des o.A. Arrays 
        mit Console.WriteLine(ia.Length); die Anzahl der Einträge aus. 
        Ändert die Anzahl der Einträge und überprüft die Ausgabe. */
        public String Todo_11()
        {
            int[] ia = { 1, 0, 2, 9, 3, 8, 4, 7, 5, 6 };
            int[] ib = { 1, 0, 2, 9, 3, 8, 4, 7 };
            String text = "11 TODO - Array length\n";
            text += "\tLength of {1, 0, 2, 9, 3, 8, 4, 7, 5, 6} = " + ia.Length + "\n";
            text += "\tLength of {1, 0, 2, 9, 3, 8, 4, 7} = " + ib.Length + "\n";
            return text;
        }
        //TODO 12
        /*Fügt den o.a. Beispielcode zu Strings einem C#-Projekt zu 
        und überprüft jeweils die Variableninhalte von 
        meinString, c, a_eq_b, a_eq_c und zeichen mit Console.WriteLine 
        oder mit dem Debugger.*/
        public String Todo_12()
        {
            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);
            string meinString = "Dies ist ein String";
            char zeichen = meinString[5];

            String text = "12 TODO - Strings\n";
            text += "\tmeinString = " + meinString + "\n";
            text += "\tc = " + c + "\n";
            text += "\ta_eq_b = " + a_eq_b + "\n";
            text += "\ta_eq_c = " + a_eq_c + "\n";
            text += "\tzeichen = " + zeichen + "\n";
            return text;
        }
        //TODO 13
        /*Schreibt ein C#-Programm, das zwei Zahlen von der Konsole einliest. 
        Diese sollen verglichen werden. Ist die erste größer als die zweite, 
        soll der Text "a ist größer als b" ausgegeben werden, 
        ansonsten der Text "b ist größer als a".*/
        public String Todo_13()
        {
            String text = "13 TODO - conditional constructs\n";
            int[] numbers = new int[2];
            for (int i = 0; i <= 1; i++)
            {
                Console.WriteLine("Input a number for G1: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            text += "\ta = " + numbers[0] + "\n";
            text += "\tb = " + numbers[1] + "\n";

            return text += (numbers[0] >= numbers[1]) ? "\ta ist größer oder gleich als b" : "\tb ist größer als a";
        }
        //TODO 14
        /*Ändert das Programm aus dem letzten TODO so ab, 
        dass wenn die erste Zahl größer drei und die zweite Zahl gleich 6 sechs ist, 
        der Text "Du hast gewonnen" ausgegeben wird. 
        Ansonsten soll "Leider verloren" ausgegeben werden. */
        public String Todo_14()
        {
            String text = "14 TODO - conditional constructs\n";
            int[] numbers = new int[2];
            for (int i = 0; i <= 1; i++)
            {
                Console.WriteLine("Input a number for G2: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            text += "\ta = " + numbers[0] + "\n";
            text += "\tb = " + numbers[1] + "\n";

            return text += ((numbers[0] > 3) && (numbers[1] == 6)) ? "\tDu hast gewonnen" : "\tb Leider verloren";
        }
        //TODO15
        public String Todo_15()
        {
            String text = "15 TODO - switch test\n\t";
            //Mit Ints
            Console.WriteLine("Input a Int: ");
            int i = int.Parse(Console.ReadLine());
            switch (i)
            {
                case 1:
                    text += "Du hast EINS eingegeben";
                    break;
                case 2:
                    text += "ZWEI war Deine Wahl";
                    break;
                case 3:
                    text += "Du tipptest eine DREI";
                    break;
                case 4:
                    text += "Du tipptest eine VIER";
                    break;
                default:
                    text += "Die Zahl " + i + " kenne ich nicht";
                    break;
            }
            text += "\n";
            Console.WriteLine("Input a String: ");
            //Mit Strings
            string j = Console.ReadLine();
            switch (j)
            {
                case "1":
                    text += "Du hast EINS eingegeben";
                    break;
                case "2":
                    text += "ZWEI war Deine Wahl";
                    break;
                case "3":
                    text += "Du tipptest eine DREI";
                    break;
                case "4":
                    text += "Du tipptest eine VIER";
                    break;
                default:
                    text += "Den String " + i + " kenne ich nicht";
                    break;
            }
            text += "\n";
            return text;
        }
        //TODO 16
        /*Versucht, die oben mit der 
        switch / case Anweisung implementierte Funktionalität mit 
        if/ else Anweisungen zu implementieren. */
        public String Todo_16()
        {
            String text = "16 TODO - rebuild switch using if/else\n\t";
            //Mit Ints
            Console.WriteLine("Input a Int: ");
            int i = int.Parse(Console.ReadLine());
            if (i == 1)
            {
                text += "Du hast EINS eingegeben";
            }
            else if (i == 2)
            {
                text += "Du hast ZWEI eingegeben";
            }
            else if (i == 3)
            {
                text += "Du hast DREI eingegeben";
            }
            else if (i == 4)
            {
                text += "Du hast VIER eingegeben";
            }
            else
            {
                text += "Die Zahl " + i + " kenne ich nicht";
            }
            text += "\n";
            return text;
        }
        //TODO 17
        /* Erzeugt ein C# Programm, das in einer while-Schleife 
        die Zahlen von 1 bis 10 auf der Konsole ausgibt. 
        Wie lauten hier die Teile <INITIALISIERUNG>, 
        <BEDINGUNG> und <INKREMENT>? */
        public String Todo_17()
        {
            String text = "17 TODO - while schleife\n\t";
            int i = 1;
            while (i <= 10)
            {
                text += i + " ";
                i++;
            }
            text += "\n";
            return text;
        }
        //TODO 18
        public String Todo_18()
        {
            String text = "18 TODO - schleifen\n\t";
            string[] someStrings = {"Hier", "sehen", "wir", "einen", "Array", "von", "Strings"};
            for (int i = 0; i < someStrings.Length; i++)
            {
                text += someStrings[i] + " ";
            }
            text += "\n";
            return text;
        }
        //ToString Method for outprint
        public override String ToString()
        {
            return Todo_1() + Todo_2() + Todo_3() + Todo_4() + Todo_5() + Todo_6() + Todo_7() + Todo_8() + Todo_9() + Todo_10() + Todo_11() + Todo_12() + Todo_13() + Todo_14() + Todo_15() + Todo_16() + Todo_17() + Todo_18();
        }

        public String ToStringWithoutInput()
        {
            return Todo_1() + Todo_2() + Todo_3() + Todo_4() + Todo_5() + Todo_6() + Todo_7() + Todo_8() + Todo_9() + Todo_10() + Todo_11() + Todo_12() + Todo_17() + Todo_18();
        }
    }
}
