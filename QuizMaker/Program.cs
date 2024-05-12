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
                
                keepPlaying = UIMethods.StopPlayPrompt(insertMoreQuiz);
                UIMethods.InsertMoreQuizReturn(insertMoreQuiz);
                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    List<QuizQuestion> quizzes = new List<QuizQuestion>();

                    //Select what to do
                    gameOption = char.ToUpper(Console.ReadKey().KeyChar);

                    //Play Quizzes Logic
                    Logics.PlayQuizSelection(gameOption, quizzes, Constants.path);

                    //Insert More Quiz Logic
                    Logics.AddMoreQuizSelect(gameOption, quizzes, options, Constants.path);
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
