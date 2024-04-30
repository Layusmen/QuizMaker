using System;
namespace QuizMaker
{
    internal class UIMethods
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("\nWelcome to the Quiz Maker");
            Console.Write("\nWhat do you want to do?:");
            Console.Write("(P) Play Quiz Game.");
            Console.Write("(A) To Add More to the question Bank.");
            Console.Write("\nPlease choose an Option (P or A): ");
        }
        public static void PrintInsertQuizPrompt()
        {
            Console.WriteLine("\nPlease insert the questions, and follow the prompts as required. \n");
        }
        public static void PrintQuizOptionsPrompt()
        {
            Console.WriteLine("\nPlease insert options\n");
        }
        public static void PrintCorrectOptionPrompt()
        {
            Console.WriteLine("Insert the right Option:");
        }
        public static void PrintCorrectOptionIndicator()
        {
            Console.WriteLine("\nCorrect Answer is:");
        }
        public static void QuestionAddedPrint()
        {
            Console.WriteLine("\nQuestion added:");
        }
        public static void InsertedOptionsPrint()
        {
            Console.WriteLine("\nThe Following are the Options Inserted: ");
        }

        public static void CorrectionOptionPrint()
        {
            Console.WriteLine("\nThe Correct Option is:");
        }
    }
}