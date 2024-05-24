using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;
namespace QuizMaker
{
    internal class UIMethods
    {
        /// <summary>
        /// Create Random Quiz
        /// </summary>
        public static Random random = new Random();
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
                    Console.WriteLine($"\nPlease press a key between {Constants.KEY_OPTIONS}.");
                }
                else
                {
                    Console.WriteLine($"\n\"Invalid key. Please press{Constants.KEY_OPTIONS}.");
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
                int numQuestions = quizzes.Count;

                    //Constants.MAX_OPTIONS;

                int money = 0;
                Console.WriteLine($"Quizzes count: {quizzes.Count}");

                for (int i = 0; i < numQuestions; i++)
                {
                    int randomIndex = new Random().Next(quizzes.Count);
                    var quiz = quizzes[randomIndex];

                    bool isCorrect = AskQuestion(quiz);
                    money += isCorrect ? 1 : 0;
                }

                MoneyWon(money);
            }
            else
            {
                Console.WriteLine("No quizzes found in the file.");
            }
        }

        /// <summary>
        /// ASK Question
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>

        public static bool AskQuestion(QuizQuestion quiz)
        {
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
            return pressedKey == quiz.correctOption[1].ToString();
        }
        /// <summary>
        /// Total Money Won Calculation
        /// </summary>
        /// <param name="money"></param>

        public static void MoneyWon (int money)
        {
            int total = 0;
            total = money;
            Console.WriteLine($"\nTotal money won {total}");
        }

        /// <summary>
        /// Print Quiz Question and Options
        /// </summary>
        /// <param name="quizzes"></param>
        public static void PrintFormattedQuizzes(List<QuizQuestion> quizzes)
        {
            //Quiz Question Print
            QuestionAddedPrint();
            foreach (QuizQuestion quiz in quizzes)
            {
                Console.WriteLine(quiz.question);

                InsertOptionsPrint();

                foreach (string option in quiz.questionOption)
                {
                    Console.WriteLine(option);
                }
                CorrectionOptionPrint();
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
        public static void ConfirmOptionInput(int counter, string labeledOption)
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
                QuizOptionOutput(counter);

                // Insert Option Console.
                string insertOption = InsertNeededOptions();

                //Invoke Option Labels
                string[] optionLabels = Constants.OPTIONLABELS;

                if (insertOption != "")
                {
                    counter++;
                    string labeledOption = $"{optionLabels[counter - 1]} {insertOption}";
                    options.Add(labeledOption);

                    //Print InsertNeededOptions Option
                    ConfirmOptionInput(counter, labeledOption);
                }

                if (counter == Constants.MAX_OPTIONS)
                {
                    LogInsertedOption();
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
        public static int ValidateAndGetCorrectOption(List<string> options)
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
        public static bool PromptForAddingMoreQuizzes()
        {
            Console.Write($"\nDo you want to add more quiz: {Constants.SMALl_LETTER_Y} or {Constants.CAPITAL_LETTER_Y} for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            // Check if the pressed key is 'y' for yes
            return key.KeyChar == Constants.SMALl_LETTER_Y || key.KeyChar == Constants.CAPITAL_LETTER_Y;
        }
       
        /// <summary>
        /// Stop the software from running
        /// </summary>
        /// <returns></returns>
        public static bool IsUserRequestingStop()
        {
            Console.Write($"\nDo you want to Go on with the Software? {Constants.SMALl_LETTER_Y} or {Constants.CAPITAL_LETTER_Y} for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar == Constants.SMALl_LETTER_Y || key.KeyChar == Constants.CAPITAL_LETTER_Y;
        }

        /// <summary>
        /// Required Option is being inserted
        /// </summary>
        public static void LogInsertedOption()
        {
            Console.WriteLine("Needed Options InsertNeededOptions");
        }

        /// <summary>
        /// Check the validity of question bank path
        /// </summary>
        /// <returns></returns>
        public static void ReportMissingQuestionBank()
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
        public static void DisplayAvailableQuizToPlay(List<QuizQuestion> quizzes)
        {
            Console.WriteLine($"\nThank you. You have the opportunity to answer {quizzes.Count} Questions?");
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

        /// <summary>
        /// Completely save quiz after the whole process
        /// </summary>
        /// <param name="quizzes"></param>
        public static void EnableQuizCreationAndSave(List<QuizQuestion> quizzes)
        {

            while (PromptForAddingMoreQuizzes())
            {
                // Insert More Quizzes to the Question Bank
                
                PrintInsertQuizPrompt();

                string insertQuestion = InsertNeededOptions();

                QuizQuestion quiz = Logics.CreateQuizQuestion(insertQuestion);

                List<string> options = CreateOptions();

                quiz.questionOption = options;

                int selectOption = ValidateAndGetCorrectOption(options);

                quiz.correctOption = GetSelectedOption(options, selectOption);

                quizzes.Add(quiz);

                Console.Clear();

                // Print Quiz Questions and Options
                PrintFormattedQuizzes(quizzes);

                // Call SaveQuizzes Method
                Logics.SaveQuizzes(quizzes);
            }
        }
    }
}