using System;
namespace QuizMaker
{
    internal class UIMethods
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Quiz Maker");
        }
        public static void InsertQuizQuestion()
        {
            Console.WriteLine("\nPlease insert the questions, and follow the prompts as required. \n");
        }
        public static List<string> Request()
        {
            List<string> keepQuestions = new List<string>();

            while (true)
            {
                UIMethods.InsertQuizQuestion();

                string insertQuiz = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(insertQuiz))
                {
                    break; 
                }

                keepQuestions.Add(insertQuiz);

               
                Console.WriteLine("Do you want to add another question? (y/n)");
                string addMore = Console.ReadLine().Trim().ToLower();

                if (addMore != "y")
                {
                    break;
                }
            }

            return keepQuestions;
        }
    }
}
