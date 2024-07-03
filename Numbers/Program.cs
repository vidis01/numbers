using Numbers.Enums;
using Numbers.Helpers;

namespace Numbers
{
    internal class Program
    {
        static void RunProgram()
        {
            bool runProgram = true;

            do
            {
                Console.Clear();

                var selectedNumberInputFormatAsString = "";
                NumberFormatEnum? selectedNumberInputFormat;
                string? numberToConvert = "";
                var isInputCorrect = true;
                int? otherFormatBase = 0;

                do
                {
                    selectedNumberInputFormatAsString = UserInputHelper.GetUserNumberFormatSelection(true);
                }
                while (!UserInputHelper.InputNumberFormatSelectionCheck(selectedNumberInputFormatAsString, out selectedNumberInputFormat));

                do
                {
                    isInputCorrect = UserInputHelper.GetNumberToConvert(selectedNumberInputFormat, out numberToConvert);

                    if (!isInputCorrect)
                    {
                        Console.WriteLine("Bloga įvestis.");
                    }
                }
                while (!isInputCorrect);

                do
                {
                    selectedNumberInputFormatAsString = UserInputHelper.GetUserNumberFormatSelection(false);
                }
                while (!UserInputHelper.InputNumberFormatSelectionCheck(selectedNumberInputFormatAsString, out selectedNumberInputFormat));

                

                //kokiu formtu

                runProgram = UserInputHelper.GetUserInputIfHeWantToContinue();
            }
            while (runProgram);
        }

        static void Main(string[] args)
        {
            RunProgram();
        }
    }
}
