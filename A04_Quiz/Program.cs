using System;
using System.Collections.Generic;

namespace A04_Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Quiz quiz = new Quiz(startingQuizelements());
            String option;
            do {
                Console.Clear();
                option = Console.ReadLine();
                switch(option){
                    case "1":
                        //Dosomething
                        break;
                    case "2":
                        //Dosomething
                        break;
                    case "3":
                        //Dosomething
                        break;
                }
            } while(option != "1");
            Console.WriteLine("Stopped");
        }

        static List<Quizelement> startingQuizelements(){
            List<Quizelement> quizelements = new List<Quizelement>();
            quizelements.Add(new Quizelement("Ist Daniel böse?","ja",new String[] {"nein"}));
            return quizelements;
        }
    }
}
