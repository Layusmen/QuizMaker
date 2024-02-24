using System;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();
            List<string> questions = UIMethods.Request();
            Logics.PrintNumberedQuestions(questions);
        }
    }

}


