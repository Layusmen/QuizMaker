using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insertMoreQuiz= true;

            char gameOption;
            do
            {
                UIMethods.PrintWelcome();

                gameOption = char.ToUpper(Console.ReadKey().KeyChar);

               if (gameOption == Constants.PLAY_QUIZ)
                {
                    List<QuizQuestion> quizzes = new List<QuizQuestion>();
                    //Play Quiz Prompt
                    Console.WriteLine("\nPlay Quiz Prompt");

                    List<QuizQuestion> loadedQuizzes= Logics.LoadDeserialize(quizzes);
                    Console.WriteLine("\nDo you want to play game?");

                    Logics.PrintQuizDeserialize(loadedQuizzes);
                    break;
                }

                if (gameOption == Constants.INSERT_MORE_QUIZ)
                {
                    // Insert Quiz Question Instances        
                    List<QuizQuestion> quizzes = new List<QuizQuestion>();

                    //Add More Quiz to the Quiz Bank Prompt 
                    Logics.PopulateQuizBank(insertMoreQuiz, quizzes);
                    break;
                }

            } while (true);

        }
    }
}