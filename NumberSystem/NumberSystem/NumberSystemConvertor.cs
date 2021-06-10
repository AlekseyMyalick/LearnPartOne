using System;

namespace NumberSystem
{
    public static class NumberSystemConvertor
    {
        static readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

        /// <summary>
        /// Converts a number from decimal to the specified number system.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        /// <param name="numberSystem">Final number system.</param>
        /// <returns></returns>
        public static string Convert(int number, int numberSystem)
        {
            NumberValidation(number);
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

        /// <summary>
        /// Check if the selected number system satisfies the boundary conditions.
        /// </summary>
        /// <param name="numberSystem">Final number system.</param>
        private static void NumberSystemValidation(int numberSystem)
        {
            if (numberSystem > 20 || numberSystem < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numberSystem), "Must be greater than 2 and less than 20.");
            }
        }

        /// <summary>
        /// Check if it is possible to translate the number into another number system.
        /// </summary>
        /// <param name="number">Number to convert.</param>
        private static void NumberValidation(int number)
        {
            if (number == int.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Must be greater than -2147483648.");
            }
        }

        /// <summary>
        /// Returns the sign of a number.
        /// </summary>
        /// <param name="number">Signed or unsigned number.</param>
        /// <returns>"-" if the number is negative, string.Empty if the number is positive.</returns>
        private static string GetNumberSign(int number)
        {
            return number < 0 ? "-" : string.Empty;
        }

        /// <summary>
        /// Reverse the sign of a number if it is negative.
        /// </summary>
        /// <param name="number">Signed or unsigned number.</param>
        private static void ChangeNegativeNumericSign(ref int number)
        {
            number = number < 0 ? -number : number;
        }

        /// <summary>
        /// Returns a number as a character.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>If less than 9, returns the character equivalent to a number, otherwise the corresponding letter.</returns>
        private static char GetRemainderSymbol(int number)
        {
            return number > 9 ? alphabet[number % 10] : ToChar(number);
        }

        /// <summary>
        /// Converts a number to a character.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Character equivalent to a number.</returns>
        private static char ToChar(int number)
        {
            return (char)(number + '0');
        }
    }
}
