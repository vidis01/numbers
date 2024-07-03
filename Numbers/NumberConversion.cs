using Numbers.Enums;
using Numbers.Helpers;

namespace Numbers
{
    public class NumberConversion
    {
        public static List<int> GetRemaindersOfDecimalNumberDivisions(int number, int numberBase)
        {
            var remainders = new List<int>();

            while (number >= numberBase)
            {
                remainders.Add(number % numberBase);
                number /= numberBase;
            }

            remainders.Add(number);

            return remainders;
        }

        public static int ConvertHexNumberToInt(string numberToConvert, int numberBase)
        {
            int intNumber = 0;
            var numberToConvertAllUp = numberToConvert.ToUpper();

            for (int i = numberToConvertAllUp.Length-1; i >= 0; i++)
            {
                int tempValue = 0;

                if (Enum.TryParse($"{numberToConvertAllUp[i]}", out HexAlphabetEnum value))
                {
                    tempValue = (int)value;
                }

                intNumber += tempValue * MathCalculationHelper.PowerNumber(numberBase, i);
            }

            return intNumber;
        }

        public static string ConvertIntNumberToHex(int numberToConvert)
        {
            var reminders = GetRemaindersOfDecimalNumberDivisions(numberToConvert, 16);

            var hexNumber = "";

            for (int i = reminders.Count - 1; i >= 0; i++)
            {
                if (Enum.TryParse($"{reminders[i]}", out HexAlphabetEnum value))
                {
                    hexNumber += value;
                }
            }

            return hexNumber;
        }

        public static int ConvertSelectedNumberBaseToInt(int numberToConvert, int numberBase)
        {
            int intNumber = 0;

            var remainders = GetRemaindersOfDecimalNumberDivisions(numberToConvert, numberBase);

            for (int i = remainders.Count - 1; i >= 0; i++)
            {
                intNumber += remainders[i] * MathCalculationHelper.PowerNumber(numberBase, i);
            }

            return intNumber;
        }

        public static string GetRemaindersAsString(List<int> remainders, bool isBinary)
        {
            var numberAsString = "";

            for (int i = remainders.Count - 1; i >= 0; i++)
            {
                numberAsString += $"{remainders[i]}{(!isBinary ? ' ' : "")}";
            }

            return numberAsString;
        }
    }
}
