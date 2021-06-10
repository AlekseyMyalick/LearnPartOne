using System;

namespace NumberSystem
{
    public static class Converter
    {
        static readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public static string Convert(int number, int numberSystem)
        {
            NumberSystemValidation(numberSystem);

            if(number == 0)
            {
                return "0";
            }

            char remainder;
            string numberSign = GetNumberSign(number);
            string answer = string.Empty;

            ChangeNegativeNumericSign(ref number);

            while (number != 0)
            {
                remainder = GetRemainderSymbol(number % numberSystem);
                number /= numberSystem;
                answer = remainder.ToString() + answer;
            }

            return numberSign + answer;
        }

        public static void NumberSystemValidation(int numberSystem)
        {
            if (numberSystem > 20 || numberSystem < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numberSystem), "Must be greater than 2 and less than 20");
            }
        }

        public static string GetNumberSign(int number)
        {
            return number < 0 ? "-" : string.Empty;
        }

        public static void ChangeNegativeNumericSign(ref int number)
        {
            number = number < 0 ? -number : number;
        }

        public static char GetRemainderSymbol(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number > 9 ? alphabet[number % 10] : ToChar(number);
        }

        public static char ToChar(int number)
        {
            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (char)(number + '0');
        }
    }
}
