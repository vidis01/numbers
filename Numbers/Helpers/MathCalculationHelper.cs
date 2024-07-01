namespace Numbers.Helpers
{
    public class MathCalculationHelper
    {
        public static int PowerNumber(int number, int power)
        {
            int poweredNumber = 1;

            for (int i = 0; i < power; i++)
            {
                poweredNumber *= number;
            }

            return poweredNumber;
        }
    }
}
