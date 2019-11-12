using System;
using System.Collections.Generic;

namespace A04_Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Quiz quiz = new Quiz(StartingQuizelements());
            Quizloop(quiz);
        }
        static void Quizloop(Quiz quiz){
            ConsoleKey choice;
            do {
                Console.Clear();
                Console.WriteLine("Menu\n\n1. answer question\n2. create question\n3. exit\n\n press the number of your choise");
                do{
                    choice = Console.ReadKey(true).Key;
                } while(choice != ConsoleKey.D1 && choice != ConsoleKey.D2 && choice != ConsoleKey.D3);
                switch(choice)
                    {
                        case ConsoleKey.D1:
                            quiz.AnswerQuestion();
                            break;
                        case ConsoleKey.D2:
                            quiz.AddQuestion();
                            break;
                    }
            } while(choice != ConsoleKey.D3);
        }
        static List<Quizelement> StartingQuizelements(){
            List<Quizelement> quizelements = new List<Quizelement>();
            quizelements.Add(new Quizelement("Ist Daniel böse?","ja",new String[] {"nein"}));
            return quizelements;
        }
    }
}
