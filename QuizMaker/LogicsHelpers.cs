using QuizMaker;

internal static class LogicsHelpers
{

    public static void CollectOptions(QuizQuestion options)
    {
        int counter = 0;

        string insertedOption;
        string prompt;

        while (counter < Constants.maxOptions)
        {
            if (counter == 0)
            {
                prompt = UIMethods.InsertQuizOptions();//"\nEnter an option or Press enter to leave blank:";
            }
            else
            {
                prompt = $"\nEnter option {counter + 1} or Press enter to leave blank:";
            }
            Console.WriteLine(prompt);

            insertedOption = Console.ReadLine().Trim();

            if (insertedOption != "")
            {
                counter++;
                options.questionOption.Add(insertedOption);
                Console.WriteLine($"\nOption {counter} inserted: {insertedOption}");
            }
            else
            {
                break;
            }
        }
    }
}