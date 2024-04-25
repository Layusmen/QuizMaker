using System;
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

            char gameOption;
            
            UIMethods.QuizmakerPrompt();

            gameOption = char.ToUpper(Console.ReadKey().KeyChar);

            if (gameOption == Constants.PLAY_QUIZ)
            {
                Console.WriteLine("Add More to the Quiz Bank");
            }
            else if (gameOption == Constants.INSERT_MORE_QUIZ)
            {

                while (insertMoreQuiz)
                {
                    //Insert More Quizzes to the Question Bank
                    UIMethods.InsertQuizQuestion();

                    //Collect Quizzes;
                    Logics.CollectQuiz(quizzes);

                    //Print Quiz Questions and Options
                    Logics.PrintQuizQuestions(quizzes);

                    Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
                    ConsoleKeyInfo key = Console.ReadKey();

                    // Check if the pressed key is 'y' for yes
                    insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';

                    // Clear the console for the next round
                    Console.Clear();

                    // Call SaveSerialize Method
                    Logics.SaveSerialize(quizzes);
            
                    // Logics.AddQuizToBank(quizzes, insertMoreQuiz);
                }
            }

        }
    }
}