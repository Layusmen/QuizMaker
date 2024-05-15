using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace QuizMaker
{

    internal class Logics
    {
        public static readonly Random random = new Random();
        /// <summary>
        /// Save Quizzes [Question, Option and Correct Option to Class]
        /// </summary>
        /// <param name="quizzes"></param>
        /// <returns></returns>
        public static List<QuizQuestion> CollectQuizzes(List<QuizQuestion> quizzes)
        {
            //Console to insert quiz question 
            string insertQuestion = UIMethods.Inserted();
            List<string> options = new List<string>();
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

        /// <summary>
        /// Add Option to the Quiz
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
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
                    UIMethods.OptionRequiredInserted();
                    break;
                }
            }
            return options;
        }

        /// <summary>
        /// Print Quiz Question and Options
        /// </summary>
        /// <param name="quizzes"></param>
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

        /// <summary>
        /// Add More Quiz to the Question Bank
        /// </summary>
        /// <param name="insertMoreQuiz"></param>
        /// <returns></returns> 
        /// </summary>
        /// <param name="gameOption"></param>
        /// <param name="quizzes"></param>
        /// <param name="PATH"></param>
        /// <param name="writer"></param>
        /// <param name="insertMoreQuiz"></param>
        /// <param name="random"></param>
        public static void AddMoreQuizSelect(char gameOption, List<QuizQuestion> quizzes, string path, XmlSerializer writer, bool insertMoreQuiz)
        {
            if (gameOption == Constants.START_ALPHABET)
            {

                PlayQuizSelection(gameOption, quizzes, path, writer);

                //Quiz XML File Path
                UIMethods.CheckQuestionBankPath(path, quizzes, writer);

                //Add More Quiz to the Quiz Bank Prompt 
                PopulateQuizBank(quizzes, path, writer, insertMoreQuiz);
            }
        }
        
        /// <summary>
        /// Selection to Play Quiz
        /// </summary>
        /// <param name="gameOption"></param>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <param name="random"></param>
        public static void PlayQuizSelection(char gameOption, List<QuizQuestion> quizzes, string path, XmlSerializer writer)
        {
            if (gameOption == Constants.PLAY_QUIZ)
            {
                //Play Quiz Prompt
                UIMethods.NumberOfQuizToPlay();
                UIMethods.QuizDisplay(quizzes, path, writer, random);
            }
        }
        
        /// <summary>
        /// Populate Quiz Bank
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <param name="insertMoreQuiz"></param>
        public static void PopulateQuizBank(List<QuizQuestion> quizzes, string path, XmlSerializer writer, bool insertMoreQuiz)
        {
            while (insertMoreQuiz)
            {
                // Insert More Quizzes to the Question Bank
                UIMethods.PrintInsertQuizPrompt();

                // Collect Quizzes;
                Logics.CollectQuizzes(quizzes);

                // Print Quiz Questions and Options
                Logics.PrintQuiz(quizzes);

                // Call SerializeSave Method
                UIMethods.SerializeSave(quizzes, path, writer);

                insertMoreQuiz = UIMethods.AddMoreQuizRequest(insertMoreQuiz);
            }
        }
        
        /// <summary>
        /// Get Valid Key When Yes or otherwise is pressed
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Reset Available Indexes
        /// </summary>
        /// <param name="availableIndexes"></param>
        /// <param name="loadedQuizzes"></param>
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