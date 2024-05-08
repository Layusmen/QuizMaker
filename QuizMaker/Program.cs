using System;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool insertMoreQuiz = true;
            char gameOption;
            bool keepPlaying = true;
            List<string> options = new List<string>();
            while (keepPlaying)
            {
                keepPlaying = Logics.StopPlayPrompt(insertMoreQuiz);
                Console.WriteLine($"Returning: {insertMoreQuiz}");
                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    List<QuizQuestion> quizzes = new List<QuizQuestion>();

                    //Select what to do
                    gameOption = char.ToUpper(Console.ReadKey().KeyChar);

                    //Play Quizzes Logic
                    Logics.PlayQuizSelection(gameOption, quizzes);

                    //Insert More Quiz Logic
                    Logics.SelectAddMoreQuiz(gameOption, quizzes, options);
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
