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
            Logics.CollectQuiz(quizzes);

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

        }
    }
}