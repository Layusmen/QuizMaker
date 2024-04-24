using Microsoft.VisualBasic.FileIO;
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
            QuizQuestion quiz = new QuizQuestion();

            while (insertQuestion != "")
            {

                quiz.question = insertQuestion;
                break;
            }

            quiz.questionOption = CollectOptions();
            quiz.correctOption = CollectRightOption(quiz);
            quizzes.Add(quiz);
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

        public static string CollectRightOption(QuizQuestion quiz)
        {
            Console.WriteLine("\nNow Enter the Correct Option of the options inserted");
            string rightOption = Console.ReadLine().Trim();

            bool foundCorrectOption = false;
            while (rightOption != "" && !foundCorrectOption)
            {
                if (quiz.questionOption.Contains(rightOption))
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
                Console.WriteLine("\nThe Following are the Options Inserted: ");
                foreach (string option in quiz.questionOption)
                {
                    Console.WriteLine(option);
                }
                Console.WriteLine("\nThe Correct Option is:");
                Console.WriteLine(quiz.correctOption);
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
