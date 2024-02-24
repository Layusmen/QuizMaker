using System.Security.Cryptography.X509Certificates;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                UIMethods.PrintWelcome();

                List<string> keepQuestions = new List<string>();
                do
                {
                    UIMethods.InsertQuizQuestion();

                    string insertQuiz = Console.Read().ToString().Trim();

                    keepQuestions.Add(insertQuiz);

                    Console.WriteLine($"Question added: {insertQuiz}");

                    Console.WriteLine("Do you want to Add more question? " +
                        "Press Y, no continue, any other key to discontinue");
                }
                while (Console.ReadKey().Key == ConsoleKey.Y);
                UIMethods.ListQuizQuestions(keepQuestions);
                Console.WriteLine("All questions listed. Press any key to exit.");
                Console.ReadKey();
            }
        }

    }
}


