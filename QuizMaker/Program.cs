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
            
            //Collect Quizzes;
            Logics.CollectQuiz(quizzes);
           
            //Select Right Option
            Logics.CollectRightOption();
            Console.WriteLine(quizzes.Count);



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