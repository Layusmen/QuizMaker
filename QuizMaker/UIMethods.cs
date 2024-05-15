using System;

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
            Console.Write("(P) Play Quiz Game.");
            Console.Write("(A) To Add More to the question Bank.");
            Console.Write("\nPlease choose an Option (P or A): ");
        }

        /// <summary>
        /// Print Insert Quiz Questions Prompt to the user
        /// </summary>
        public static void PrintInsertQuizPrompt()
        {
            Console.WriteLine("\nPlease insert the Quiz questions followed by five (5) options. \n");
        }
        /// <summary>
        /// Print Insert Quiz Questions Prompt to the user
        /// </summary>
        public static void PrintQuizOptionsPrompt()
        {
            Console.WriteLine("\nPlease insert options\n");
        }
        /// <summary>
        /// Print Insert Correct Quiz Option Prompt to the user
        /// </summary>
        public static void PrintCorrectOptionPrompt()
        {
            Console.WriteLine("Insert the right Option:");
        }

        /// <summary>
        /// Print Insert Correct Quiz Option Indicator Prompt to the user
        /// </summary>
        public static void PrintCorrectOptionIndicator()
        {
            Console.WriteLine("\nCorrect Answer is:");
        } 

        /// <summary>
        /// Print Question Added Prompt to the user
        /// </summary>
        public static void QuestionAddedPrint()
        {
            Console.WriteLine("\nQuestion added:");
        }

        /// <summary>
        /// Inserted Options Print to the user
        /// </summary>
        public static void InsertedOptionsPrint()
        {
            Console.WriteLine("\nThe Following are the Options Inserted: ");
        }

        /// <summary>
        /// Correct Option Print to the user
        /// </summary>
        public static void CorrectionOptionPrint()
        {
            Console.WriteLine("\nThe Correct Option is:");
        }

        /// <summary>
        /// Quiz DIsplay Print to user
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <param name="random"></param>
        public static void QuizDisplay(List<QuizQuestion> quizzes, string path, XmlSerializer writer, Random random)
        {
            List<QuizQuestion> loadedQuizzes = DeserializeLoad(quizzes, path, writer);

            if (loadedQuizzes != null && loadedQuizzes.Any())
            {
                //var random = new Random();
                int numQuestions = Constants.MAX_OPTIONS;
                int money = 0;
                int total = 0;
                // list of available question indices
                List<int> availableIndexes = Enumerable.Range(0, loadedQuizzes.Count).ToList();

                for (int i = 0; i < numQuestions; i++)
                {
                    // Check if all questions have all been answered

                    Logics.ResetIndexes(availableIndexes, loadedQuizzes);
                    // Select a random question from available ones
                    int randomIndex = availableIndexes[random.Next(availableIndexes.Count)];

                    // Display the question

                    var quiz = loadedQuizzes[randomIndex];
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

                    string pressedKey = Logics.GetValidKey();

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
        /// Meant to collect input
        /// </summary>
        /// <returns></returns>
        public static string Inserted()
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
                UIMethods.PrintQuizOptionsPrompt();
            }
            else
            {
                prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
            }
        }

        /// <summary>
        /// Inserted Options Print to the user
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
        public static string CollectRightOption(List<string> options)
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

            string rightOption;
            if (selectedOption >= 1 && selectedOption <= options.Count)
            {
                rightOption = options[selectedOption - 1];
                Console.WriteLine("You selected: " + selectedOption);
                return rightOption;
            }

            else
            {
                // possible out of range selectedOption
                Console.WriteLine("An unexpected error occurred. No option selected.");
                return null;
            }
        }

        /// <summary>
        /// Save Question, Options anc Correct Option to the XML File.
        /// Serialise the data to XML format.
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        public static void SerializeSave(List<QuizQuestion> quizzes, string path, XmlSerializer writer)
        {
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }
            Console.WriteLine("Quizzes saved to file:");
            writer.Serialize(Console.Out, quizzes);
        }
        
        /// <summary>
        /// Prompt to Add more quiz
        /// </summary>
        /// <param name="insertMoreQuiz"></param>
        /// <returns></returns>
        public static bool AddMoreQuizRequest(bool insertMoreQuiz)
        {
            Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            // Check if the pressed key is 'y' for yes
            return key.KeyChar == 'y' || key.KeyChar == 'Y';
        }
        /// <summary>
        /// Deserialize Load the Quiz Questions from the XML File.
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static List<QuizQuestion> DeserializeLoad(List<QuizQuestion> quizzes, string path, XmlSerializer writer)
        {
            if (!File.Exists(path)) // Check if file exists
            {
                Console.WriteLine("File Path Does Not Exist");
                return null;
            }
            else
            {
                Console.WriteLine("File Path Found");

                using (FileStream file = File.OpenRead(path))
                {
                    //XmlSerializer reader = new XmlSerializer(typeof(List<QuizQuestion>));
                    quizzes = (List<QuizQuestion>)writer.Deserialize(file);
                }
            }
            return quizzes;
        }
        /// <summary>
        /// Print Deserialize Quiz Questions, Options and Correct Option  to the user.
        /// </summary>
        /// <param name="quizzes"></param>
        public static void PrintQuizDeserialize(List<QuizQuestion> quizzes)
        {
            if (quizzes != null && quizzes.Any())
            {
                Console.WriteLine("Loaded Quiz Questions:");
                foreach (var quiz in quizzes)
                {
                    // Access and display question
                    Console.WriteLine("Question: {0}", quiz.question);
                    Console.WriteLine("Options:");
                    foreach (var option in quiz.questionOption)
                    {
                        Console.WriteLine("- {0}", option);
                    }
                    Console.WriteLine("Answer: {0}", quiz.correctOption);
                    Console.WriteLine("...");
                }
            }
            else
            {
                Console.WriteLine("No quizzes found in the file.");
            }
        }
        /// <summary>
        /// Stop the software from running
        /// </summary>
        /// <param name="insertMoreQuiz"></param>
        /// <returns></returns>
        public static bool StopPlayPrompt(bool insertMoreQuiz)
        {
            Console.Write("\nDo you want to Go on with the Software? 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            // Check if the pressed key is any key except lowercase 'y'
            insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';
            Console.WriteLine($"Pressed key: {key.KeyChar}");
            return insertMoreQuiz;
        }
        /// <summary>
        /// Inserted Key to Add to Quiz Bank
        /// </summary>
        /// <returns></returns>
        public static ConsoleKeyInfo AskToAddQuiz()
        {
            Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();
            return key;
        }
        /// <summary>
        /// Enter Key Pressed Prompt
        /// </summary>
        public static void EnterKeyPressed()
        {
            Console.WriteLine("\nPlease press a key between A, B, C, D, or E.");
        }
        /// <summary>
        /// Indicate that an Invalid Key was Pressed
        /// </summary>
        public static void InvalidKeyPressed()
        {
            Console.WriteLine("\nInvalid key. Please press A, B, C, D, or E.");
        }
        /// <summary>
        /// Show how many quiz to play
        /// </summary>
        public static void NumberOfQuizToPlay()
        {
            Console.WriteLine("\nPlay Quiz Prompt");
            Console.WriteLine("\nYou have the opportunity to answer 5 Questions?");
        }
        /// <summary>
        /// Print Restart Quiz Prompt
        /// </summary>
        public static void PrintRestartQuiz()
        {
            Console.WriteLine("You have answered all questions! Restarting quiz...");
        }
        /// <summary>
        /// Show Insert More Quiz is being inserted
        /// </summary>
        public static void InsertMoreQuizReturn(bool insertMoreQuiz)
        {
            Console.WriteLine($"Returning: {insertMoreQuiz}");
        }
        /// <summary>
        /// Required Option is being inserted
        /// </summary>
        public static void OptionRequiredInserted()
        {
            Console.WriteLine("Needed Options Inserted");
        }

        /// <summary>
        /// Check Question Bank Path Whether ther are Quizzes Saved Already
        /// </summary>
        /// <param name="path"></param>
        /// <param name="quizzes"></param>
        /// <param name="writer"></param>
        public static void CheckQuestionBankPath(string path, List<QuizQuestion> quizzes, XmlSerializer writer)
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
                quizzes = UIMethods.DeserializeLoad(quizzes, path, writer);
            }
        }

    }
}