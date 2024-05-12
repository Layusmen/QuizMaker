﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logics
    {
        public static List<QuizQuestion> CollectQuizzes(List<QuizQuestion> quizzes, List<string> options)
        {

            string insertQuestion = UIMethods.Inserted();

            QuizQuestion quiz = new QuizQuestion();

            while (insertQuestion != "")
            {
                quiz.question = insertQuestion;
                break;
            }
            quiz.questionOption = CollectOptions(options);
            quiz.correctOption = UIMethods.CollectRightOption(options);

            quizzes.Add(quiz);
            return quizzes;
        }
        public static List<string> CollectOptions(List<string> options)
        {
            int counter = 0;
            while (counter < Constants.MAX_OPTIONS)
            {
                UIMethods.QuizOptionOutput(counter);

                // Insert Option Console.
                string insertedOption = UIMethods.Inserted();
                
                //Invoke Option Labels
                string[] optionLabels = Constants.OPTIONLABELS;

                if (insertedOption != "")
                {
                    counter++;
                    string labeledOption = $"{optionLabels[counter - 1]} {insertedOption}"; 
                    options.Add(labeledOption);
                    
                    //Print Inserted Option
                    UIMethods.OptionInserted(counter, labeledOption);
                }
                if (counter == Constants.MAX_OPTIONS)
                {
                    Console.WriteLine("Needed Options Inserted");
                    break;
                }
            }
            return options;
        }
        public static void PrintQuiz(List<QuizQuestion> quizzes)
        {
            //Quiz Question Print
            UIMethods.QuestionAddedPrint();
            foreach (QuizQuestion quiz in quizzes)
            {
                Console.WriteLine(quiz.question);

                UIMethods.InsertedOptionsPrint();

                foreach (string option in quiz.questionOption)
                {
                    Console.WriteLine(option);
                }
                UIMethods.CorrectionOptionPrint();
                Console.WriteLine(quiz.correctOption);
            }
        }
        public static bool ToAddMoreQuizPrompt(bool insertMoreQuiz)
        {
            ConsoleKeyInfo key = UIMethods.AskToAddQuiz();
            // Check if the pressed key is 'y' for yes
            insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';
            if (insertMoreQuiz)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void AddMoreQuizSelect(char gameOption, List<QuizQuestion> quizzes, List<string> options, string path)
        {
            if (gameOption == Constants.START_ALPHABET)
            {

                PlayQuizSelection(gameOption, quizzes, path);

                //Quiz XML File Path
                CheckQuestionBankPath(path, quizzes);

                //Add More Quiz to the Quiz Bank Prompt 
                Logics.PopulateQuizBank(quizzes, options, path);
            }
        }
        public static void PopulateQuizBank(List<QuizQuestion> quizzes, List<string> options, string path)
        {
            // Insert More Quizzes to the Question Bank
            UIMethods.PrintInsertQuizPrompt();

            // Collect Quizzes;
            Logics.CollectQuizzes(quizzes, options);

            // Print Quiz Questions and Options
            Logics.PrintQuiz(quizzes);

            // Call SerializeSave Method
            UIMethods.SerializeSave(quizzes, path);
        }

        public static void CheckQuestionBankPath(string path, List<QuizQuestion> quizzes)
        {
            if (string.IsNullOrEmpty(path))
            {
                Console.WriteLine("Path is empty");
            }

            if (!File.Exists(path))
            {
                Console.WriteLine("No already saved quizzes");
            }
            else
            {
                Console.WriteLine("\nSome Quizes already saved\n");
                quizzes = UIMethods.DeserializeLoad(quizzes, path);
            }
        }
        public static void PlayQuizSelection(char gameOption, List<QuizQuestion> quizzes, string path)
        {
            if (gameOption == Constants.PLAY_QUIZ)
            {
                //Play Quiz Prompt
                UIMethods.NumberOfQuizToPlay();
                UIMethods.QuizDisplay(quizzes, path);
            }
        }
       
        public static string GetValidKey()
        {
            bool isValid = false;
            string pressedKey = null;
            while (!isValid)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (char.ToUpper(keyInfo.KeyChar) >= Constants.START_ALPHABET && char.ToUpper(keyInfo.KeyChar) <= Constants.END_ALPHABET)
                {
                    pressedKey = char.ToUpper(keyInfo.KeyChar).ToString();
                    isValid = true;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    UIMethods.EnterKeyPressed();
                }
                else
                {
                    UIMethods.InvalidKeyPressed();
                }
            }
            return pressedKey;
        }
        public static void ResetIndexes(List<int> availableIndexes, List<QuizQuestion> loadedQuizzes)
        {
            if (availableIndexes.Count == 0)
            {
                UIMethods.PrintRestartQuiz();
                availableIndexes = Enumerable.Range(0, loadedQuizzes.Count).ToList();
            }
        }
    }
}