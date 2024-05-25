using System;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;

namespace QuizMaker
{
    internal class Program
    {
        public static List<QuizQuestion> quizzes = new List<QuizQuestion>();

        static void Main(string[] args)
        {
            char gameOption;

            //Start up the software//

            while (UIMethods.IsUserRequestingStop())
            {
                //Welcome Message
                UIMethods.PrintWelcome();

                //Select what to do
                gameOption = UIMethods.GetSelectedOption();

                if (gameOption == Constants.PLAY_QUIZ)
                {
                    quizzes = Logics.ReadQuizzesFromFile();

                    //Play Quiz Prompt
                    UIMethods.DisplayNumberOfAvailableQuizzesToPlay(quizzes);

                    UIMethods.DisplayQuiz(quizzes);
                }

                if (gameOption == Constants.ADD_MORE_QUESTION_MODE)
                {

                    //Quiz XML File Path
                    UIMethods.ReportMissingQuestionBank();

                    // Deserialize XML File
                    quizzes = Logics.ReadQuizzesFromFile();

                    UIMethods.EnableQuizCreationAndSave(quizzes);
                }
            }
        }
    }
}
