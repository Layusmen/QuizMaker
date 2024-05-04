﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logics
    {
        public static List<QuizQuestion> CollectQuizzes(List<QuizQuestion> quizzes)
        {
            string insertQuestion = Console.ReadLine().Trim();


            QuizQuestion quiz = new QuizQuestion();

            while (insertQuestion != "")
            {
                quiz.question = insertQuestion;
                break;
            }
            quiz.questionOption = CollectOptions();
            quiz.correctOption = CollectRightOption(quiz);

            quizzes.Add(quiz);
            return quizzes;
        }
        public static List<string> CollectOptions()
        {
            int counter = 0;
            string insertedOption;
            List<string> options = new List<string>();

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
        public static string CollectRightOption(QuizQuestion quiz)
        {
            Console.WriteLine("\nNow Enter the Correct Option of the options inserted");
            string rightOption = Console.ReadLine().Trim();

            bool foundCorrectOption = false;
            while (rightOption != "" && !foundCorrectOption)
            {
                if (quiz.questionOption.Contains(rightOption))
                {
                    foundCorrectOption = true;
                    Console.WriteLine("Correct Answer Found in the Options Bank");
                }
            }
            return rightOption;
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
        public static void PopulateQuizBank(List<QuizQuestion> quizzes)
        {
            // Insert More Quizzes to the Question Bank
            UIMethods.PrintInsertQuizPrompt();

            // Collect Quizzes;
            Logics.CollectQuizzes(quizzes);

            // Print Quiz Questions and Options
            Logics.PrintQuiz(quizzes);


            // Call SaveSerialize Method
            Logics.SaveSerialize(quizzes);


            //PromptToAddMoreQuiz(insertMoreQuiz);

        }
        public static void SelectAddMoreQuiz(char gameOption, List<QuizQuestion> quizzes)
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
                Logics.PopulateQuizBank(quizzes);
            }
        }
        public static void PlayQuizSelection(char gameOption)
        {
            if (gameOption == Constants.PLAY_QUIZ)
            {
                List<QuizQuestion> quizzes = new List<QuizQuestion>();

                //Play Quiz Prompt
                Console.WriteLine("\nPlay Quiz Prompt");

                List<QuizQuestion> loadedQuizzes = Logics.LoadDeserialize(quizzes);
                Console.WriteLine("\nDo you want to play game?");

                Logics.PrintQuizDeserialize(loadedQuizzes);
            }
        }
        public static bool StopPlay(bool insertMoreQuiz)
        {
            Console.Write("\nDo you want to Go on with the Software? 'y' for yes, any other key for no): ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            // Check if the pressed key is any key except lowercase 'y'
            insertMoreQuiz = key.KeyChar == 'y' || key.KeyChar == 'Y';
            Console.WriteLine($"Pressed key: {key.KeyChar}");
            return insertMoreQuiz;
        }
        public static void PlayQuizSelection1(char gameOption)
        {
            if (gameOption == Constants.PLAY_QUIZ)
            {
                List<QuizQuestion> quizzes = new List<QuizQuestion>();

                //Play Quiz Prompt
                Console.WriteLine("\nPlay Quiz Prompt");


                var path = @"C:\Users\ola\source\repos\QuizMaker\QuestionBank";

                if (!File.Exists(path)) // Check if file exists
                {
                    Console.WriteLine("File Path Does Not Exist");

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





                Console.WriteLine("\nDo you want to play game?");



                //PrintQuizDeserialize(quizzes);

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
        }
    }
}
