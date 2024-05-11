using System;
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

        public static void QuizDisplay(List<QuizQuestion> quizzes)
        {
            List<QuizQuestion> loadedQuizzes = Logics.DeserializeLoad(quizzes);
            //string[] optionLabels = { "(A)", "(B)", "(C)", "(D)", "(E)" };

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
                    // Check if all questions have been displayed
                    if (availableIndexes.Count == 0)
                    {
                        Console.WriteLine("You have answered all questions! Restarting quiz...");
                        availableIndexes = Enumerable.Range(0, loadedQuizzes.Count).ToList();
                    }

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
                    Console.WriteLine("\nSelect the Correct Option");
                    bool validKey = false;
                    string pressedKey = null;
                    Console.WriteLine("The correct option is" + quiz.correctOption);
                    while (!validKey)
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (char.ToUpper(keyInfo.KeyChar) >= 'A' && char.ToUpper(keyInfo.KeyChar) <= 'E')
                        {
                            pressedKey = char.ToUpper(keyInfo.KeyChar).ToString();
                            validKey = true;
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
    }
}