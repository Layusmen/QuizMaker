using System;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insertMoreQuiz = true;
            //Insert Quiz Question            
            List<QuizQuestion> quizzes = new List<QuizQuestion>();
            UIMethods.PrintWelcome();

            while (insertMoreQuiz)
            {

                UIMethods.InsertQuizQuestion();

                //Collect Quizzes;
                Logics.CollectQuiz(quizzes);

                //Print Quiz Questions and Options
                Logics.PrintQuizQuestions(quizzes);


                Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' for yes
                insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Clear the console for the next round
                Console.Clear();
            }

            //Serialization [Outputing for programming sake, to clear off latter]
            Console.WriteLine("Quizzes saved to file:");
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
            var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }
            writer.Serialize(Console.Out, quizzes);

        }
    }
}