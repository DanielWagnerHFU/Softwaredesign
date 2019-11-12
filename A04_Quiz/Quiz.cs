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

        }
        public Boolean AnswerQuestion(){
            return false;
        }
    }
}