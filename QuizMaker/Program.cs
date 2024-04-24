using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insertMoreQuiz = true;
            //Insert Quiz Question Instances        
            List<QuizQuestion> quizzes = new List<QuizQuestion>();
            UIMethods.PrintWelcome();

            Console.Write("\nWhat do you want to do?:");
            char gameOption;

            while (true)
            {
                Console.Write("(A) Answer Quiz Questions.");
                Console.Write("(B) To Add More to the question Bank.");
                Console.Write("\nPlease choose an Option (A or B): ");
                gameOption = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (gameOption == Constants.PLAY_QUIZ)
                {
                    //Play Quiz Functionality Selected
                    Logics.AddQuizToBank(quizzes, insertMoreQuiz);
                    break;
                }
                else if (gameOption == Constants.INSERT_MORE_QUIZ)
                {
                    Console.WriteLine("Add More to the Quiz Bank");
                }   
            }
        }
    }
}