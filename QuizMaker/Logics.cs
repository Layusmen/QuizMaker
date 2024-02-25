using System;

namespace QuizMaker
{
    internal class Logics
    {
        public static List<string> GetQuizOptions()
        {
            List<string> options = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter an option or Press enter to leave blank:");
                string option = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(option))
                {
                    break; 
                }
                options.Add(option);
            }
            return options;
        }

        public static void DisplayQuizzes(List<QuizQuestion> quizzes)
        {
            Console.WriteLine("Created Quizzes:");
            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"Question: {quiz.question}");
                Console.WriteLine("Options:");
                foreach (var option in quiz.options)
                {
                    Console.WriteLine($"{option}");
                }
                Console.WriteLine("\tCorrect Option: {quiz.correctOption}");
                Console.WriteLine();
            }
        }
    }
}
