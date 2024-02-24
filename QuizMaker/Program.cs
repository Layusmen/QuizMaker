using System;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();

            UIMethods.InsertQuizQuestion();
            List <QuizQuestion> quizzes = new List<QuizQuestion>();


            QuizQuestion quiz = new QuizQuestion();

            //Insert Quiz Question
            string insertedQuestion = Console.ReadLine().Trim();
            insertedQuestion = quiz.question;

            //Insert Quiz Options
            UIMethods.InsertQuizOptions();
            quiz.options = Console.ReadLine().Trim();


            //Insert Quiz Options
            UIMethods.InsertCorrectOption();

            quizzes.Add(quiz);

        }
    }

}


