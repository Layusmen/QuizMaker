﻿using System;
using System.Diagnostics;
namespace QuizMaker
{
    internal class UIMethods
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Quiz Maker");
        }
        public static void InsertQuizQuestion()
        {
            Console.WriteLine("\nPlease insert the questions, and follow the prompts as required. \n");
        }
        public static void InsertQuizOptions()
        {
            Console.WriteLine("\nPlease insert options\n");
        }
        public static void InsertCorrectOption() 
        { 
            Console.WriteLine("Inserted the right Option"); 
        }
    }
}