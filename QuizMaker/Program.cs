﻿using System;
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


            while (UIMethods.GetStop())
            {
                //Welcome Message
                UIMethods.PrintWelcome();

                //Select what to do
                gameOption = UIMethods.GetSelectedOption();

                if (gameOption == Constants.PLAY_QUIZ)
                {
                    //Play Quiz Prompt
                    UIMethods.NumberOfGameToPlayPrint();

                    quizzes = Logics.LoadQuizzes(Logics.writer);

                    UIMethods.DisplayQuiz(quizzes);
                }

                if (gameOption == Constants.ADD_MORE_QUESTION_MODE)
                {

                    //Quiz XML File Path
                    UIMethods.ValidateQuestionBankPath();
                    
                    // Deserialize XML File
                    Logics.DeserializeFile(quizzes);

                    UIMethods.SaveCompleteQuiz(quizzes);
                }
            }
        }
    }
}
