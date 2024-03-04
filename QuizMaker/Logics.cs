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
            
            string insertedOption;
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
                    options.questionOption.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
                }
                else
                {
                   
                    break;
                }
            }
        }

        public static void CollectRightOption(List<QuizQuestion> quizzes)
        {
            string rightOption = Console.ReadLine().Trim();
            QuizQuestion correct;
            if (rightOption != "")
            {
                correct = new QuizQuestion();
                correct.correctOption = rightOption;
                quizzes.Add(correct);
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
