using System;
using System.Security.Cryptography.X509Certificates;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();
            UIMethods.InsertQuizQuestion();

            //Insert Quiz Question            
            List<QuizQuestion> quizzes = new List<QuizQuestion>();
            
            Logics.CollectQuiz(quizzes);

            //Quiz Question object
            QuizQuestion options = new QuizQuestion();

            Logics.CollectOptions(options);

            //Print Quiz Questions
            Logics.PrintQuizQuestions(quizzes);

            //Print Quiz Options
            Logics.PrintQuizOptions(options);

        }
    }
}