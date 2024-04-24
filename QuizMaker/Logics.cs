using System;
using System.Data;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logics
    {
    
        public static List<QuizQuestion> CollectQuiz(List<QuizQuestion> quizzes)
        {
            string insertQuestion = Console.ReadLine().Trim();

            if (insertQuestion != "")
            {
                QuizQuestion quiz = new QuizQuestion();
                quiz.question = insertQuestion;
                quiz.questionOption = CollectOptions();
                quiz.correctOption = CollectRightOption();
                quizzes.Add(quiz);
            }
            return quizzes;
        }

        public static List<string> CollectOptions()
        {
            int counter = 0;
            string insertedOption;
            List<string> options = new List<string>();

            string prompt;
            while (counter < Constants.maxOptions)
            {
                if (counter == 0)
                {
                   UIMethods.InsertQuizOptions();
                }
                else
                {
                    prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
                }
         
                insertedOption = Console.ReadLine().Trim();

                if (insertedOption != "")
                {
                    counter++;
                    options.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
                }

                if (counter == Constants.maxOptions)
                {
                    Console.WriteLine("Needed Options Inserted");
                    break; 
                }
            }
            return options;
        }

        public static string CollectRightOption()
        {
            Console.WriteLine("\nNow Enter the Correct Option of the options inserted");
            string rightOption = Console.ReadLine().Trim();

            bool foundCorrectOption = false;
            while (rightOption != "" && !foundCorrectOption)
            {
                if (CollectOptions().Contains(rightOption))
                {
                    foundCorrectOption = true;
                    Console.WriteLine("Correct Answer Found in the Options Bank");
                }
            }
            return rightOption;
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
        public static void PrintCorrectOption(List<QuizQuestion> quizzes)
        {

            foreach (QuizQuestion correctAnswer in quizzes)
            {
                Console.WriteLine(correctAnswer.correctOption);
            }
        }
    }
}
