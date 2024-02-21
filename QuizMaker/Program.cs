namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.PrintWelcome();

            UIMethods.InsertQuizQuestion();

            List<string> keepQuestions = new List<string>();

            string insertQuiz = Console.ReadLine().Trim();

            keepQuestions.Add(insertQuiz);
            Console.WriteLine($"Question added: {insertQuiz}");

            Console.WriteLine("\nDo you want to add another question? (y/n):");
            string answer = Console.ReadLine().Trim().ToLower();

            Console.WriteLine(keepQuestions);

        }
    }
}
