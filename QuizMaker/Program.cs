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

                //Play Quizzes Prompt
                Logics.PlayQuiz(insertMoreQuiz, gameOption);

               //Insert Nore Quiz Logic
                Logics.AddMoreQuiz(insertMoreQuiz, gameOption);

            } while (true);

        }
    }
}