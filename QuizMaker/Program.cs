using System;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Text;

namespace QuizMaker
{
    internal class Program
    {
        
        public static List<QuizQuestion> quizzes = new List<QuizQuestion>();
        static void Main(string[] args)
        {
            
            bool insertMoreQuiz = true;
            char gameOption;
            bool keepPlaying = true;
            
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
            
            while (keepPlaying)
            {
                //Start up the software//
                keepPlaying = UIMethods.StopPlayPrompt(insertMoreQuiz);
                
                UIMethods.InsertMoreQuizReturn(insertMoreQuiz);
                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    //Initialise QuizQuestion Class
                    //List<QuizQuestion> quizzes = new List<QuizQuestion>();

                    //Select what to do
                    gameOption = char.ToUpper(Console.ReadKey().KeyChar);

                    //Play Quizzes Logic
                    Logics.PlayQuizSelection(gameOption, quizzes, Constants.path, writer);

                    //Insert More Quiz Logic
                    Logics.AddMoreQuizSelect(gameOption, quizzes, Constants.path, writer, insertMoreQuiz);

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
