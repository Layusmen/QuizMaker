using System;
namespace QuizMaker
{
    internal class UIMethods
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("\nWelcome to the Quiz Maker");
            Console.Write("\nWhat do you want to do?:");
            Console.Write("(A) Answer Quiz Questions.");
            Console.Write("(B) To Add More to the question Bank.");
            Console.Write("\nPlease choose an Option (A or B): ");
        }
        public static void InsertQuizPrompt()
        {
            Console.WriteLine("\nPlease insert the questions, and follow the prompts as required. \n");
        }
        public static void InsertQuizOptions()
        {
            Console.WriteLine("\nPlease insert options\n");
        }
        public static void InsertCorrectOption()
        {
            Console.WriteLine("Insert the right Option:");
        }
        public static void PromptCorrectOption()
        {
            Console.WriteLine("\nCorrect Answer is:");
        }
    }
}