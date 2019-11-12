using System;
using System.Collections.Generic;

namespace A04_Quiz
{
    class Quiz
    {
        private List<Quizelement> quizelements;
        private int points;
        private List<Quizelement> answeredQuestions;
        public Quiz(List<Quizelement> quizelements){
            this.quizelements = quizelements;
            this.points = 0;
            this.answeredQuestions = new List<Quizelement>();
        }
        public void AddQuestion(){
            Console.WriteLine("Added something");
            System.Threading.Thread.Sleep(5000);
        }
        public void AnswerQuestion(){
            Console.Clear();
            var random = new Random();
            int index = random.Next(quizelements.Count);
            Quizelement element = quizelements[index];
        }
        public void ShowQuizMenu(){
            Console.Clear();
            Console.WriteLine("Menu\n\n1. answer question\n2. create question\n3. exit\n");
            Console.WriteLine("answered questions: " + GetAnsweredQuestions());
            Console.WriteLine("points            : " + GetPoints());
            Console.WriteLine("\npress the key of your choice");
        }
        public int GetPoints(){
            return this.points;
        }
        public int GetAnsweredQuestions(){
            return this.answeredQuestions.Count;
        }
    }
}