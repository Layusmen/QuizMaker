using System;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;

namespace QuizMaker
{
    internal class Program
    {
        public static readonly Random random = new Random();

        public static List<QuizQuestion> quizzes = new List<QuizQuestion>();
        public static List<string> options = new List<string>();
        public static QuizQuestion quiz = new QuizQuestion();
        static void Main(string[] args)
        {
            
            bool insertMoreQuiz = true;
            char gameOption;
            bool keepPlaying = true;
            
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
            
            while (keepPlaying)
            {
                //Start up the software//
                keepPlaying = UIMethods.StopPlayPrompt(insertMoreQuiz);

                if (keepPlaying)
                {
                    //Welcome Message
                    UIMethods.PrintWelcome();

                    //Select what to do
                    gameOption = char.ToUpper(Console.ReadKey().KeyChar);

                    //Play Quizzes Logic
                    //Logics.PlayQuizSelection(gameOption, quizzes, writer);
                    
                    if (gameOption == Constants.PLAY_QUIZ)
                    {
                        //Play Quiz Prompt
                        UIMethods.NumberOfGameToPlayPrint();

                        quizzes = UIMethods.LoadQuizzes(writer);
                        
                        UIMethods.QuizDisplay(quizzes, writer, random);
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

                            quiz = Logics.CreateQuizQuestion(quiz);

                            quiz.questionOption = UIMethods.CreateOptions(options);
                            
                            int selectedOption = UIMethods.CreateRightOption(options);
                            
                            quiz.correctOption = UIMethods.GetSelectedOption(options, selectedOption);
                            
                            quizzes.Add(quiz);
                            
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
