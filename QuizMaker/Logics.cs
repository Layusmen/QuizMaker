using System;
using System.Data;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logics
    {
        public static void CollectQuiz(List<QuizQuestion> quizzes, List<string> options)
        {
            string insertQuestion = Console.ReadLine().Trim();

            if (insertQuestion != "")
            {
                QuizQuestion quiz = new QuizQuestion();
                //quiz.question = insertQuestion;
                //quiz.questionOption = CollectOptions();
                quizzes.Add(quiz);
            }
            

        }



        public static List<string> CollectOptions()
        {
            int counter = 0;
            string insertedOption;

            //QuizQuestion quiz = new QuizQuestion();
            List<string> options = new List<string>();
            string prompt;
            
            while (counter < Constants.maxOptions)
            {

                if (counter == 0)
                {
                    prompt = UIMethods.InsertQuizOptions();//"\nEnter an option or Press enter to leave blank:";
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

                    options.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
                }
                else
                {
                    break;
                }
            }
            return options;
        }


        public static void CollectRightOption(QuizQuestion option, List<QuizQuestion> quizzes)
        {
            string rightOption;
            while (true)
            {
                QuizQuestion correct;
                rightOption = Console.ReadLine().Trim();
                if (rightOption == "")
                {
                    Console.WriteLine("Please enter a valid option.");
                    continue;
                }

                if (option.questionOption.Contains(rightOption))
                {
                    Console.WriteLine("Correct Answer Found in the Options Bank");
                    correct = new QuizQuestion();
                    correct.correctOption = rightOption;
                    quizzes.Add(correct);
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
        public static void PrintCorrectOption(List<QuizQuestion> quizzes)
        {

            foreach (QuizQuestion correctAnswer in quizzes)
            {
                Console.WriteLine(correctAnswer.correctOption);
            }
        }
    }
}
