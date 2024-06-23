using Numbers.Enums;
using Numbers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    public class NumberConversion
    {
        private int ConvertHexNumberToInt(string numberToConvert, int numberBase)
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

        public string ConvertIntNumberToSelectedNumberBase(int numberToConvert, int numberBase)
        {


            return "";
        }


    }
}
