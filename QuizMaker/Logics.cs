using System;

namespace QuizMaker
{
    internal class Logics
    {
        public static List<string> GetQuizOptions()
        {
            List<string> options = new List<string>();

            while (true)
            {
                Console.WriteLine("Enter an option (or leave blank to finish):");
                bool validOption = false;
               
                    string option = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(option))
                    {
                        break; // Exit loop if empty option is entered
                    }
                while (!validOption)
                {
                    validOption = GetQuizOptions().Contains(option);
                    if (!validOption)
                    {
                        Console.WriteLine("Error: The entered correct option is not present in the options list. Please enter a valid option:");
                    }
                    options.Add(option);
                }
            }

            return options;
        }

    }
}
