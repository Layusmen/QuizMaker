using Microsoft.VisualBasic.FileIO;
using System;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();

            List<QuizQuestion> quizes = new List<QuizQuestion>();

            while (true)
            {
                UIMethods.InsertQuizQuestion();

                QuizQuestion quiz = new QuizQuestion();

                //Insert Quiz Question
                string insertedQuestion = Console.ReadLine().Trim();
                insertedQuestion = quiz.question;

                //Insert Quiz Options
                UIMethods.InsertQuizOptions();
                quiz.options = Logics.GetQuizOptions();

                //Insert Quiz Options
                UIMethods.InsertCorrectOption();
                quiz.correctOption = Console.ReadLine().Trim();

                //Add each quiz into List Quizzes
                quizes.Add(quiz);

                Console.WriteLine("Do you want to add another question? (y/n)");
                string addMoreQuestion = Console.ReadLine().Trim().ToLower();

                if (addMoreQuestion != "y")
                {
                    break;
                }  
            }
        }
    }

}