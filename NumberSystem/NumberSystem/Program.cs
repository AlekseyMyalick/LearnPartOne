using System;

namespace NumberSystem
{
    class Program
    {
        static readonly char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };

        static void Main(string[] args)
        {
            try
            {
                string result = Converter(int.Parse(args[0]), int.Parse(args[1]));
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string Converter(int number, int numberSystem)
        {
            if (numberSystem > 20 || numberSystem < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numberSystem), "Must be greater than 2 and less than 20");
            }

            char remainder;
            string numberSign = GetNumberSign(number);
            string answer = string.Empty;

            ChangeNumberSign(ref number);

            while (number != 0)
            {
                remainder = GetRemainderSymbol(number % numberSystem);
                number /= numberSystem;
                answer = remainder.ToString() + answer;
            }

            return numberSign + answer;
        }

        static string GetNumberSign(int number)
        {
            return number < 0 ? "-" : string.Empty;
        }

        static void ChangeNumberSign(ref int number)
        {
            number = number < 0 ? -number : number;
        }

        static char GetRemainderSymbol(int number)
        {
            return number > 9 ? alphabet[number % 10] : ToChar(number);
        } 

        static char ToChar(int number)
        {
            return (char)(number + '0');
        }
    }
}
