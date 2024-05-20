﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace QuizMaker
{
    internal class UIMethods
    {
        /// <summary>
        /// Print Welcome message and menu options to the user
        /// </summary>
        public static void PrintWelcome()
        {
            Console.WriteLine("\nWelcome to the Quiz Maker");
            Console.Write("\nWhat do you want to do?:");
            Console.Write($"({Constants.PLAY_QUIZ}) Play Quiz Game.");
            Console.Write($"({Constants.ADD_MORE_QUESTION_MODE}) To Add More to the question Bank.");
            Console.Write($"\nPlease choose an Option ({Constants.PLAY_QUIZ} or {Constants.ADD_MORE_QUESTION_MODE}): ");
        }

        /// <summary>
        /// Print Insert Quiz Questions Prompt to the user
        /// </summary>
        public static void PrintInsertQuizPrompt()
        {
            Console.WriteLine($"\nPlease insert the Quiz questions followed by five ({Constants.MAX_OPTIONS}) options. \n");
        }
        
        
        /// <summary>
        /// Print Question Added Prompt to the user
        /// </summary>
        public static void QuestionAddedPrint()
        {
            Console.WriteLine("\nQuestion added:");
        }

        /// <summary>
        /// InsertNeededOptions Options Print to the user
        /// </summary>
        public static void InsertOptionsPrint()
        {
            Console.WriteLine("\nThe Following are the Options InsertNeededOptions: ");
        }

        /// <summary>
        /// Correct Option Print to the user
        /// </summary>
        public static void CorrectionOptionPrint()
        {
            Console.WriteLine("\nThe Correct Option is:");
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

                if (char.ToUpper(keyInfo.KeyChar) >= Constants.ADD_MORE_QUESTION_MODE && char.ToUpper(keyInfo.KeyChar) <= Constants.LAST_OPTION)
                {
                    pressedKey = char.ToUpper(keyInfo.KeyChar).ToString();
                    isValid = true;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("\nPlease press a key between A, B, C, D, or E.");
                }
                else
                {
                    Console.WriteLine("\nInvalid key. Please press A, B, C, D, or E.");
                }
            }
            return pressedKey;

        }
        /// <summary>
        /// Display Quizzes, Options and Correct Option to the user
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="writer"></param>
        /// <param name="random"></param>
        public static void DisplayQuiz(List<QuizQuestion> quizzes)
        {
            if (quizzes != null && quizzes.Any())
            {
               
                int numQuestions = Constants.MAX_OPTIONS;
                int money = 0;
                int total = 0;
                Console.WriteLine($"Quizzes count: {quizzes.Count}");

                for (int i = 0; i < numQuestions; i++)
                {
                    Console.WriteLine("Iteration: {0}", i);

                   
                    Random random = new Random();
                    int randomIndex = random.Next(quizzes.Count);
                    var quiz = quizzes[randomIndex];

                    Console.WriteLine("Question: {0}", quiz.question);
                    Console.WriteLine("Options:");
                    int j = 0;
                    foreach (var option in quiz.questionOption)
                    {
                        Console.WriteLine(option);
                        j++;
                    }
                    Console.WriteLine("The correct option is" + quiz.correctOption);
                    Console.WriteLine("\nNow Select the Correct Option");

                    string pressedKey = GetValidKey();

                    if (pressedKey == quiz.correctOption[1].ToString())
                    {
                        money += 1;
                        Console.WriteLine($"\nYou won {money}");
                        Console.WriteLine("Correct! You pressed " + pressedKey);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect. The correct option was " + quiz.correctOption);
                    }
                }
                total = money;
                Console.WriteLine($"Total money won {total}");
            }
            else
            {
                Console.WriteLine("No quizzes found in the file.");
            }
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

                UIMethods.InsertOptionsPrint();

                foreach (string option in quiz.questionOption)
                {
                    Console.WriteLine(option);
                }
                UIMethods.CorrectionOptionPrint();
                Console.WriteLine(quiz.correctOption);
            }
        }

        /// <summary>
        /// Meant to collect input
        /// </summary>
        /// <returns></returns>
        public static string InsertNeededOptions()
        {
            string insert = Console.ReadLine().Trim();
            return insert;
        }

        /// <summary>
        /// Quiz Option Output Print to the user
        /// </summary>
        /// <param name="counter"></param>
        public static void QuizOptionOutput(int counter)
        {
            string prompt;
            if (counter == 0)
            {
                Console.WriteLine("\nPlease insert options\n");
            }
            else
            {
                prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
            }
        }

        /// <summary>
        /// InsertNeededOptions Options Print to the user
        /// </summary>
        /// <param name="counter"></param>
        /// <param name="labeledOption"></param>
        public static void OptionInserted(int counter, string labeledOption)
        {
            Console.WriteLine($"\nOption {counter} inserted: {labeledOption}");
        }

        /// <summary>
        /// Collecting the right option from the user
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        

        public static string GetSelectedOption(List<string> options, int selectedOption)
        {
            if (selectedOption >= 1 && selectedOption <= options.Count)
            {
                return options[selectedOption - 1];
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Add Option to the Quiz
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> CreateOptions()
        {
            List<string> options = new List<string>();
            int counter = 0;
            while (counter < Constants.MAX_OPTIONS)
            {
                UIMethods.QuizOptionOutput(counter);

                // Insert Option Console.
                string insertOption = UIMethods.InsertNeededOptions();

                //Invoke Option Labels
                string[] optionLabels = Constants.OPTIONLABELS;

                if (insertOption != "")
                {
                    counter++;
                    string labeledOption = $"{optionLabels[counter - 1]} {insertOption}";
                    options.Add(labeledOption);

                    //Print InsertNeededOptions Option
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
        /// Insert the right option to the quiz
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static int CreateRightOption(List<string> options)
        {
            Console.WriteLine("\nNow Enter the Correct Option Index of the options inserted");
            int selectedOption;
            bool isValidInput = false;
            do
            {
                Console.WriteLine("Enter a number between 1 and 5 (inclusive): ");

                string userInput = Console.ReadLine().Trim();

                // Validate user input with TryParse
                isValidInput = int.TryParse(userInput, out selectedOption);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            } while (!isValidInput || selectedOption < 1 || selectedOption > Constants.MAX_OPTIONS);
            return selectedOption;
        }
        /// <summary>
        /// Prompt to Add more quiz
        /// </summary>
        /// <param name="insertMoreQuiz"></param>
        /// <returns></returns>
        public static bool AddMoreQuizRequest()
        {
            Console.Write($"\nDo you want to add more quiz: {Constants.SMALl_LETTER_Y} or {Constants.CAPITAL_LETTER_Y} for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            // Check if the pressed key is 'y' for yes
            return key.KeyChar == Constants.SMALl_LETTER_Y || key.KeyChar == Constants.CAPITAL_LETTER_Y;
        }
        /// <summary>
        /// Deserialize Load the Quiz Questions from the XML File.
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static List<QuizQuestion> DeserializeLoad(List<QuizQuestion> quizzes, XmlSerializer writer)
        {
            if (!File.Exists(Constants.PATH)) // Check if file exists
            {
                Console.WriteLine("File Path Does Not Exist");
                return null;
            }
            else
            {
                Console.WriteLine("File Path Found");
                using (FileStream file = File.OpenRead(Constants.PATH))
                {
                    //XmlSerializer reader = new XmlSerializer(typeof(List<QuizQuestion>));
                    quizzes = (List<QuizQuestion>)writer.Deserialize(file);
                }
            }
            return quizzes;
        }

        /// <summary>
        /// Stop the software from running
        /// </summary>
        /// <returns></returns>
        public static bool GetStop()
        {
            Console.Write($"\nDo you want to Go on with the Software? {Constants.SMALl_LETTER_Y} or {Constants.CAPITAL_LETTER_Y} for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar == Constants.SMALl_LETTER_Y || key.KeyChar == Constants.CAPITAL_LETTER_Y;
        }

        
        /// <summary>
        /// Required Option is being inserted
        /// </summary>
        public static void OptionRequiredInserted()
        {
            Console.WriteLine("Needed Options InsertNeededOptions");
        }

        /// <summary>
        /// Check the validity of question bank path
        /// </summary>
        /// <returns></returns>
        public static void ValidateQuestionBankPath()
        {
            if (string.IsNullOrEmpty(Constants.PATH))
            {
                Console.WriteLine("Path is empty");
            }

            if (!File.Exists(Constants.PATH))
            {
                Console.WriteLine("No already saved quizzes");
            }
       }

        /// <summary>
        /// Tell users the number of questions to be asked
        /// </summary>
        public static void NumberOfGameToPlayPrint()
        {
            Console.WriteLine("\nThank you. You have the opportunity to answer 5 Questions?");
        }

        /// <summary>
        /// Option Selected by the user
        /// </summary>
        /// <returns></returns>
        public static char GetSelectedOption()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char gameOption = char.ToUpper(keyInfo.KeyChar);
            return gameOption;
        }
    }
}