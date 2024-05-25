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
        /// <summary>
        /// XML Serializer
        /// </summary>
        public static XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestion>));
        
        /// <summary>
        /// Quiz DIsplay Print to user
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        /// <param name="random"></param>
        public static List<QuizQuestion> ReadQuizzesFromFile()
        {
            // Initialize empty list
            List<QuizQuestion> quizzes = new List<QuizQuestion>(); 

            // Check if file exists
            if (File.Exists(Constants.PATH)) 
            {
                using (FileStream file = File.OpenRead(Constants.PATH))
                {
                    quizzes = (List<QuizQuestion>)writer.Deserialize(file);
                }
            }
            return quizzes;
            
        }

        /// <summary>
        /// Create Quiz Questions
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>
        public static QuizQuestion CreateQuizQuestion(string insertQuestion)
        {
            QuizQuestion quiz = new QuizQuestion();
            if(insertQuestion != "")
            {
                quiz.question = insertQuestion;
            }
            return quiz ;
        }
        
        /// <summary>
        /// Save Question, Options anc Correct Option to the XML File.
        /// Serialise the data to XML format.
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="path"></param>
        /// <param name="writer"></param>
        public static void SaveQuizzes(List<QuizQuestion> quizzes)
        {
            using (FileStream file = File.Create(Constants.PATH))
            {
                writer.Serialize(file, quizzes);
            }

            writer.Serialize(Console.Out, quizzes);
        }
    }
}