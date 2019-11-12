using System;

namespace A04_Quiz
{
    class Quizelement
    {
        private String question;
        private String rightAnswer;
        private String[] wrongAnswers;
        public Quizelement(String question, String rightAnswer, String[] wrongAnswers){
            this.question = question;
            this.rightAnswer = rightAnswer;
            this.wrongAnswers = wrongAnswers;
        }
        public String GetQuestion(){
            return this.question;
        }
        public String GetRightAnswer(){
            return this.rightAnswer;
        }
        public String[] GetWrongAnswers(){
            return this.wrongAnswers;
        }
    }
}