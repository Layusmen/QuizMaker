﻿using System;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class Constants
    {
        public static string[] OPTIONLABELS = new string[] { "(A)", "(B)", "(C)", "(D)", "(E)" };
        public const int MAX_OPTIONS = 5;
        public const char PLAY_QUIZ = 'P';
        public const char ADD_MORE_QUESTION_MODE = 'A';
        public const char LAST_OPTION = 'E';
        public const string PATH = @"..\..\..\QuestionBank.xml";
        public const char SMALl_LETTER_Y = 'y';
        public const char CAPITAL_LETTER_Y = 'Y';
        public const string KEY_OPTIONS = "Invalid key. Please press A, B, C, D, or E";
    }
}
