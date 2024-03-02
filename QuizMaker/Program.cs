using System;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();
            UIMethods.InsertQuizQuestion();
            //Insert Quiz Question            
            List<QuizQuestion> quizzes = new List<QuizQuestion>();
            string insertQuestion = Console.ReadLine().Trim();
            if (insertQuestion != "")
            {

                QuizQuestion quiz = new QuizQuestion();
                quiz.question = insertQuestion;
                quizzes.Add(quiz);
                //quizzes.Add(new QuizQuestion { question = quiz.question });
            }


            //Print Options
            int counter = 0;

            QuizQuestion options = new QuizQuestion();
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
                    prompt = $"\nEnter option {counter + 1}  or Press enter to leave blank:";
                }
                Console.WriteLine(prompt);

                insertedOption = Console.ReadLine().Trim();

                if (insertedOption != "")
                {
                    counter++;
                    options.questionOption.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");

                }

            }
            //Quiz Question Print
            Console.WriteLine("\nQuestion added:");

            foreach (QuizQuestion quiz in quizzes)
            {
                Console.WriteLine(quiz.question);
            }

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