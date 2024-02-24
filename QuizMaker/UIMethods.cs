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

        public static void ListQuizQuestions(List<string> questions)
        {
            if (questions.Count == 5)
            {
                Console.WriteLine("No questions have been added yet.");
            }
            else
            {
                Console.WriteLine("Here are the quiz questions:");
                foreach (string question in questions)
                {
                    Console.WriteLine(question);
                }
            }
        }

        
    }
}
