using System;
using System.Xml.Serialization;

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
            QuizQuestion quiz = UIMethod.CollectQuiz(); Logics.CollectQuiz(quizzes);
            quizzes.Add(quiz);

            //Quiz Question object
            QuizQuestion options = new QuizQuestion();
            options.questionOption = new List<string>();

            Logics.CollectOptions(options);
            
            Console.WriteLine("\nWhich of the Options is correct?");
            
            Logics.CollectRightOption(options, quizzes);
            
            //Print Quiz Questions
            Logics.PrintQuizQuestions(quizzes);

            //Print Quiz Options
            Logics.PrintQuizOptions(options);

            //Correct Answer
            Console.WriteLine("\nCorrect Answer is:");
            Logics.PrintCorrectOption(quizzes);

            //Serialization
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
            var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }

            writer.Serialize(Console.Out, quizzes);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}