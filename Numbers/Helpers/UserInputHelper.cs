using Numbers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers.Helpers
{
    internal class UserInputHelper
    {
        public static bool InputNumberFormatSelectionCheck(
            string? input, out NumberFormatEnum? numberFormatEnum)
        {
            if (input == null)
            {
                numberFormatEnum = null;
                return false;
            }

            if (Enum.TryParse(input, out NumberFormatEnum value))
            {
                if (Enum.IsDefined(typeof(NumberFormatEnum), value))
                {
                    numberFormatEnum = value;
                    return true;
                }
            }

            numberFormatEnum = null;
            return false;
        }

        public static string GetUserNumberFormatSelection(bool input)
        {
            Console.WriteLine($"Pasirinkite iš sąrašo, kokiu formatu {(input ? "įvesite" : "atspausdinti") } skaičių: ");
            Console.WriteLine("10 - Desimtainis");
            Console.WriteLine(" 2 - Dvejetainis");
            Console.WriteLine(" 8 - Astuntainis");
            Console.WriteLine("16 - Sesioliktainis");
            Console.WriteLine(" 0 - Kitas");

            var inputNumberFormatSelection = Console.ReadLine();

            return inputNumberFormatSelection ?? "";
        }

    }
}
