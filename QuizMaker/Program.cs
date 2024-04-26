using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insertMoreQuiz= true;
            
            // Insert Quiz Question Instances        
            List<QuizQuestion> quizzes = new List<QuizQuestion>();

            UIMethods.PrintWelcome();

            char gameOption = char.ToUpper(Console.ReadKey().KeyChar);

            if (gameOption == Constants.PLAY_QUIZ)
            {
                //Console.WriteLine("Add More to the Quiz Bank");
            }
            else if (gameOption == Constants.INSERT_MORE_QUIZ)
            {
                //Add More Quiz to the Quiz Bank Prompt 
                Logics.QuestionPrompt(insertMoreQuiz, quizzes);
            }

        }
    }
}