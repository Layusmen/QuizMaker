﻿using System;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;

namespace QuizMaker
{
    internal class Program
    {
        //public static readonly Random random = new Random();

        public static List<QuizQuestion> quizzes = new List<QuizQuestion>();
        //public static 
        
        public static XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
        static void Main(string[] args)
        {
            
            bool insertMoreQuiz = true;
            char gameOption;
            bool keepPlaying = true;
            
           
            
            while (keepPlaying)
            {
                //Start up the software//
                keepPlaying = UIMethods.StopPlayPrompt(insertMoreQuiz);

                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    //Select what to do
                    gameOption = UIMethods.GetSelectedOption();

                    if (gameOption == Constants.PLAY_QUIZ)
                    {
                        //Play Quiz Prompt
                        UIMethods.NumberOfGameToPlayPrint();

                        quizzes = UIMethods.LoadQuizzes(writer);
                        
                        UIMethods.QuizDisplay(quizzes, writer);
                    }

                    if (gameOption == Constants.START_ALPHABET)
                    {

                        //Quiz XML File Path
                        UIMethods.ValidateQuestionBankPath();
                        UIMethods.LoadQuestionBankFromFile();
                        
                        // Deserialize XML File
                        Logics.DeserializeFile(quizzes, writer);

                        while (insertMoreQuiz)
                        {
                            // Insert More Quizzes to the Question Bank
                            UIMethods.PrintInsertQuizPrompt();

                           QuizQuestion quiz = Logics.CreateQuizQuestion();

                            List <string> options = UIMethods.CreateOptions();

                            quiz.questionOption = options;

                            int selectedOption = UIMethods.CreateRightOption(options);
                            
                            quiz.correctOption = UIMethods.GetSelectedOption(options, selectedOption);
                            
                            quizzes.Add(quiz);
                            Console.Clear();
                            // Print Quiz Questions and Options
                            UIMethods.PrintQuiz(quizzes);

                            // Call SerializeSave Method
                            Logics.SerializeSave(quizzes, writer);
                            
                            insertMoreQuiz = UIMethods.AddMoreQuizRequest(insertMoreQuiz);
                        }
                    }
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
