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
            bool insertMoreQuiz = true;
            char gameOption;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                keepPlaying  = Logics.StopPlay(insertMoreQuiz);
                Console.WriteLine($"Returning: {insertMoreQuiz}");
                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    //Select what to do
                    gameOption = char.ToUpper(Console.ReadKey().KeyChar);

                    //Play Quizzes Logic
                    Logics.PlayQuizSelection(gameOption);

                    List<QuizQuestion> quizzes = new List<QuizQuestion>();
                    //Insert More Quiz Logic
                    Logics.SelectAddMoreQuiz(gameOption, quizzes);
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}