using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Serialization;
namespace QuizMaker
{
    internal class UIMethods
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("\nWelcome to the Quiz Maker");
            Console.Write("\nWhat do you want to do?:");
            Console.Write("(P) Play Quiz Game.");
            Console.Write("(A) To Add More to the question Bank.");
            Console.Write("\nPlease choose an Option (P or A): ");
        }
        public static void PrintInsertQuizPrompt()
        {
            Console.WriteLine("\nPlease insert the Quiz questions followed by five (5) options. \n");
        }
        public static void PrintQuizOptionsPrompt()
        {
            Console.WriteLine("\nPlease insert options\n");
        }
        public static void PrintCorrectOptionPrompt()
        {
            Console.WriteLine("Insert the right Option:");
        }
        public static void PrintCorrectOptionIndicator()
        {
            Console.WriteLine("\nCorrect Answer is:");
        }
        public static void QuestionAddedPrint()
        {
            Console.WriteLine("\nQuestion added:");
        }
        public static void InsertedOptionsPrint()
        {
            Console.WriteLine("\nThe Following are the Options Inserted: ");
        }
        public static void CorrectionOptionPrint()
        {
            Console.WriteLine("\nThe Correct Option is:");
        }
        public static void QuizDisplay(List<QuizQuestion> quizzes, string path)
        {
            List<QuizQuestion> loadedQuizzes = DeserializeLoad(quizzes, path);

            if (loadedQuizzes != null && loadedQuizzes.Any())
            {
                var random = new Random();
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
        public static string Inserted()
        {
            string insert = Console.ReadLine().Trim();
            return insert;
        }
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
        public static void OptionInserted(int counter, string labeledOption)
        {
            Console.WriteLine($"\nOption {counter} inserted: {labeledOption}");
        }
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
        public static void SerializeSave(List<QuizQuestion> quizzes, string path)
        {
            //Serialization [Outputing for programming sake, to clear off latter]
            Console.WriteLine("Quizzes saved to file:");

            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));

            //var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";

            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }
            writer.Serialize(Console.Out, quizzes);
        }
        public static List<QuizQuestion> DeserializeLoad(List<QuizQuestion> quizzes, string path)
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
                    XmlSerializer reader = new XmlSerializer(typeof(List<QuizQuestion>));
                    quizzes = (List<QuizQuestion>)reader.Deserialize(file);
                }
            }
            return quizzes;
        }
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

        public static bool StopPlayPrompt(bool insertMoreQuiz)
        {
            Console.Write("\nDo you want to Go on with the Software? 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            // Check if the pressed key is any key except lowercase 'y'
            insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';
            Console.WriteLine($"Pressed key: {key.KeyChar}");
            return insertMoreQuiz;
        }
        public static ConsoleKeyInfo AskToAddQuiz()
        {
            Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
             ConsoleKeyInfo key = Console.ReadKey();
            return key;
        }
        public static void EnterKeyPressed()
        {
            Console.WriteLine("\nPlease press a key between A, B, C, D, or E.");
        }
        public static void InvalidKeyPressed()
        {
            Console.WriteLine("\nInvalid key. Please press A, B, C, D, or E.");
        }

        public static void NumberOfQuizToPlay()
        {
            Console.WriteLine("\nPlay Quiz Prompt");
            Console.WriteLine("\nYou have the opportunity to answer 5 Questions?");
        }

        public static void PrintRestartQuiz()
        {
            Console.WriteLine("You have answered all questions! Restarting quiz...");
        }
        public static void InsertMoreQuizReturn(bool insertMoreQuiz)
        {
            Console.WriteLine($"Returning: {insertMoreQuiz}");
        }
    }
}