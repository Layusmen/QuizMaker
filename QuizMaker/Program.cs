using System;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Insert Quiz Question            
            List<QuizQuestion> quizzes = new List<QuizQuestion>();

            UIMethods.PrintWelcome();

            UIMethods.InsertQuizQuestion();
            
            
            
            //Collect Quizzes;
            Logics.CollectQuiz(quizzes);
            
         


/*

            //Print Quiz Questions
            Logics.PrintQuizQuestions(quizzes);


             //Print Quiz Options
             //Logics.PrintQuizOptions(options);

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
     */

        }
    }
}