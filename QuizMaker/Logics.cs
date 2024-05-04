using Microsoft.VisualBasic.FileIO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logics
    {
        public static List<QuizQuestion> CollectQuizzes(List<QuizQuestion> quizzes, List<string> options)
        {
            string insertQuestion = Console.ReadLine().Trim();


            QuizQuestion quiz = new QuizQuestion();

            while (insertQuestion != "")
            {
                quiz.question = insertQuestion;
                break;
            }
            quiz.questionOption = CollectOptions(options);
            quiz.correctOption = CollectRightOption(options);

            quizzes.Add(quiz);
            return quizzes;
        }
        public static List<string> CollectOptions(List<string> options)
        {
            int counter = 0;
            string insertedOption;
           

            string prompt;
            while (counter < Constants.MAX_OPTIONS)
            {
                if (counter == 0)
                {
                    UIMethods.PrintQuizOptionsPrompt();
                }
                else
                {
                    prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
                }

                insertedOption = Console.ReadLine().Trim();

                if (insertedOption != "")
                {
                    counter++;
                    options.Add(insertedOption);
                    Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
                }

                if (counter == Constants.MAX_OPTIONS)
                {
                    Console.WriteLine("Needed Options Inserted");
                    break;
                }
            }
            return options;
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
        public static void SaveSerialize(List<QuizQuestion> quizzes)
        {
            //Serialization [Outputing for programming sake, to clear off latter]
            Console.WriteLine("Quizzes saved to file:");

            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));

            var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";

            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, quizzes);
            }
            writer.Serialize(Console.Out, quizzes);
        }
        public static List<QuizQuestion> LoadDeserialize(List<QuizQuestion> quizzes)
        {
            // Deserialization
            var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";

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
        public static bool PromptToAddMoreQuiz(bool insertMoreQuiz)
        {
            Console.Write("\nDo you want to add more quiz: 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey();

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
        public static void PopulateQuizBank(List<QuizQuestion> quizzes, List<string> options)
        {
            // Insert More Quizzes to the Question Bank
            UIMethods.PrintInsertQuizPrompt();

            // Collect Quizzes;
            Logics.CollectQuizzes(quizzes, options);

            // Print Quiz Questions and Options
            Logics.PrintQuiz(quizzes);


            // Call SaveSerialize Method
            Logics.SaveSerialize(quizzes);


            //PromptToAddMoreQuiz(insertMoreQuiz);

        }
        public static void SelectAddMoreQuiz(char gameOption, List<QuizQuestion> quizzes, List <string> options)
        {
            if (gameOption == Constants.INSERT_MORE_QUIZ)
            {

                PlayQuizSelection(gameOption);
                // Insert Quiz Question Instances


                var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";

                if (!File.Exists(path))
                {
                    Console.WriteLine("No already saved quizzes");
                }
                else
                {
                    Console.WriteLine("\nSome Quizes already saved\n");
                    quizzes = LoadDeserialize(quizzes);
                }
                //Add More Quiz to the Quiz Bank Prompt 
                Logics.PopulateQuizBank(quizzes, options);
            }
        }
        public static void PlayQuizSelection(char gameOption)
        {
            if (gameOption == Constants.PLAY_QUIZ)
            {
                List<QuizQuestion> quizzes = new List<QuizQuestion>();

                //Play Quiz Prompt
                Console.WriteLine("\nPlay Quiz Prompt");

                //List<QuizQuestion> loadedQuizzes = Logics.LoadDeserialize(quizzes);
                
                
                Console.WriteLine("\nYou have the opportunity to answer 5 Questions?");
                
                QuizDisplay(quizzes);



            }
        }

        public static void QuizDisplay(List<QuizQuestion> quizzes)
        {
            Console.WriteLine("Loaded first Quiz Question, option and correct option:");

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

        public static void QuizDisplay2(List<QuizQuestion> quizzes)
        {
            Console.WriteLine("Loaded first Quiz Question, option and correct option:");

            if (quizzes.Count == 0)
            {
                Console.WriteLine("No quiz questions found.");
                return;
            }

            // Access and display the first question
            QuizQuestion firstQuestion = quizzes[0];

            Console.WriteLine("Question: {0}", firstQuestion.question);
            Console.WriteLine("Options:");

            // Display options
            foreach (var option in firstQuestion.questionOption)
            {
                Console.WriteLine("- {0}", option);
            }

            Console.WriteLine("Answer: {0}", firstQuestion.correctOption);
            Console.WriteLine("...");
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
        
    }
}
