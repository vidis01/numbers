using Numbers.Enums;
using System.Diagnostics;

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

        public static bool GetUserInputIfHeWantToContinue()
        {
            bool isInputCorrect = false;
            bool doContinue = false;

            do
            {
                Console.WriteLine("Ar norėsite įvesti kitą skaičių ( y / n )?");

                var input = Console.ReadKey();

                switch (input.KeyChar.ToString().ToUpper())
                {
                    case "Y":
                        doContinue = true;
                        isInputCorrect = true;
                        break;
                    case "N":
                        return false;
                    default:
                        Console.WriteLine("Bloga įvestis.");
                        Console.WriteLine();
                        break;
                }
            }
            while (!isInputCorrect);            

            return doContinue;
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

        public static bool GetNumberToConvert(NumberFormatEnum? numberFormatEnum, out string? numberToConvert)
        {
            bool isNumberEnteredCorrectly = true;
            numberToConvert = null;
            string? userInput = "";

            switch (numberFormatEnum)
            {
                case NumberFormatEnum.Desimtainis:
                    Console.WriteLine("Įveskite DEŠIMTAINĮ skaičių:");

                    userInput= Console.ReadLine();

                    if (!int.TryParse(userInput, out _))
                        isNumberEnteredCorrectly = false;
                    else
                        numberToConvert = userInput;

                    break;
                case NumberFormatEnum.Dvejetainis:
                    Console.WriteLine("Įveskite DVEJETINĮ skaičių:");

                    userInput = Console.ReadLine();

                    if (userInput != null)
                    {
                        foreach (var item in userInput)
                        {
                            if (!(item == '0' ^ item == '1'))
                            {
                                return false;
                            }
                        }
                        numberToConvert = userInput;
                    }
                    else
                    {
                        isNumberEnteredCorrectly = false;
                    }
                    break;
                case NumberFormatEnum.Astuntainis:
                    Console.WriteLine("Įveskite AŠTUNTAINĮ skaičių:");

                    userInput = Console.ReadLine();

                    if (userInput != null && userInput != "")
                    {
                        foreach (var item in userInput)
                        {
                            if (item < 48 || item > 55)
                            {
                                return false;
                            }
                        }
                        numberToConvert = userInput;
                    }
                    else
                    {
                        isNumberEnteredCorrectly = false;
                    }
                    break;
                case NumberFormatEnum.Sesioliktainis:
                    Console.WriteLine("Įveskite ŠEŠIOLIKTAINĮ skaičių:");

                    userInput = Console.ReadLine();

                    if (userInput != null && userInput != "")
                    {
                        foreach (var item in userInput.ToUpper())
                        {
                            if ((item < 48 || item > 57) && (item < 65 || item > 70))
                            {
                                return false;
                            }
                        }
                        numberToConvert = userInput;
                    }
                    else
                    {
                        isNumberEnteredCorrectly = false;
                    }
                    break;
                case NumberFormatEnum.Kitas: //padarysiu veliau
                    isNumberEnteredCorrectly = false;
                    numberToConvert = null;
                    break;
                default:
                    isNumberEnteredCorrectly = false;
                    numberToConvert = null;
                    break;
            }

            return isNumberEnteredCorrectly;
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
