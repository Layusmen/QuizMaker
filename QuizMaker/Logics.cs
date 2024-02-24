using System;

namespace QuizMaker
{
    internal class Logics
    {
        public static void PrintNumberedQuestions(List<string> questions)
        {
            int number = 1;
            for (int question = 0; question < questions.Count; question++)
            {
                Console.WriteLine($"\nQuestion {number}");
                Console.WriteLine($"{questions[question]}");
                number++;
            }
        }
    }
}
