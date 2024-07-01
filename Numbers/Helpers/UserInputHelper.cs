using Numbers.Enums;

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

        public static bool UserSelectedNumberFormatInput(out int? numberBase)
        {
            numberBase = null;

            Console.WriteLine("Įveskite skaičiaus pagrindą iš intervalo 17..99:");

            var userInput = Console.ReadLine();

            var isInputNumber = int.TryParse(userInput, out var number);

            if (!isInputNumber) return false;

            if (number < 17 || number > 99) return false;

            numberBase = number;

            return true;
        }

        public static void PrintNumber(int number)
        {
            Console.WriteLine();
            Console.WriteLine("---------- Skaičius DEŠIMTAINIU formatu ----------");
            Console.WriteLine($"          {number}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void PrintNumber(string hexNumber)
        {
            Console.WriteLine();
            Console.WriteLine("---------- Skaičius ŠEŠIOLIKTAINIU formatu ----------");
            Console.WriteLine($"          {hexNumber}");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void PrintNumber(string number, int numberBase)
        {
            Console.WriteLine();
            Console.WriteLine($"---------- Skaičius, kurio pagrindas {numberBase} ----------");
            Console.WriteLine($"         {number}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine();
        }
    }
}
