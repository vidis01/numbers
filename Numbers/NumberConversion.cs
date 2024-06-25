using Numbers.Enums;
using Numbers.Helpers;

namespace Numbers
{
    public class NumberConversion
    {
        private static List<int> GetRemaindersOfDecimalNumberDivisions(int number, int numberBase)
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

        private static int ConvertHexNumberToInt(string numberToConvert, int numberBase)
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

        public static int ConvertIntNumberToSelectedNumberBase(int numberToConvert, int numberBase)
        {
            int intNumber = 0;

            var remainders = GetRemaindersOfDecimalNumberDivisions(numberToConvert, numberBase);

            for (int i = remainders.Count - 1; i >= 0; i++)
            {
                intNumber += remainders[i] * MathCalculationHelper.PowerNumber(numberBase, i);
            }

            return intNumber;
        }
    }
}
