using System;

namespace QuizMaker
{
    internal class Logics
    {
        public static void CollectQuiz(List<QuizQuestion> quizzes)
        {
            string insertQuestion = Console.ReadLine().Trim();

            if (insertQuestion != "")
            {
                QuizQuestion quiz = new QuizQuestion();
                quiz.question = insertQuestion;
                quizzes.Add(quiz);
            }
        }
        public static void CollectOptions(QuizQuestion options)
        {
            int counter = 0;
            options.questionOption = new List<string>();
            string insertedOption;
            string prompt;

            while (counter < Constants.maxOptions)
            {
                if (counter == 0)
                {
                    prompt = "\nEnter an option or Press enter to leave blank:";
                }
                else
                {
                    prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
                }
                Console.WriteLine(prompt);

                insertedOption = Console.ReadLine().Trim();

                if (insertedOption != "")
                {
                    counter++;
                    options.questionOption.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
                }
                else
                {
                    // If user enters nothing, break the loop to avoid exceeding maxOptions
                    break;
                }
            }
        }
        public static void PrintQuizQuestions(List<QuizQuestion> quizzes)
        {
            //Quiz Question Print
            Console.WriteLine("\nQuestion added:");

            foreach (QuizQuestion quiz in quizzes)
            {
                Console.WriteLine(quiz.question);
            }
        }
        public static void PrintQuizOptions(QuizQuestion options)
        {
            //Quiz Options Print
            Console.WriteLine("\nEntered options for this question:");
            // Print all options from the list
            foreach (var option in options.questionOption)
            {
                Console.WriteLine(option);
            }
        }
    }
}
