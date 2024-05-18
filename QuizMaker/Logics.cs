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
        /// Create Quiz Questions
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>
        public static QuizQuestion CreateQuizQuestion()
        {
            // Console to insert quiz question 
            string insertQuestion = UIMethods.InsertedInput();
            QuizQuestion quiz = new QuizQuestion();
            if(insertQuestion != "")  //TODO: needs rethinking =)
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
        public static void SerializeSave(List<QuizQuestion> quizzes, XmlSerializer writer)
        {
            using (FileStream file = File.Create(Constants.PATH))
            {
                writer.Serialize(file, quizzes);
            }

            writer.Serialize(Console.Out, quizzes);
        }

        /// <summary>
        /// Deserialize the XML File.
        /// </summary>
        /// <param name="quizzes"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static List<QuizQuestion> DeserializeFile(List<QuizQuestion> quizzes, XmlSerializer writer)
        {
            using (FileStream file = File.OpenRead(Constants.PATH))
            {
                quizzes = (List<QuizQuestion>)writer.Deserialize(file);
            }
            return quizzes;
        }

    }
}