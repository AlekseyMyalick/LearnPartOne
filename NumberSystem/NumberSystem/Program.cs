using System;

namespace NumberSystem
{
    class Program
    {
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
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Can not be less than zero.");
            }

            if (numberSystem > 20 || numberSystem < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numberSystem), "Must be greater than 2 and less than 20");
            }

            char remainder;
            string answer = string.Empty;
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G'};

            while (number != 0)
            {
                remainder = number % numberSystem > 9 ? alphabet[(number % numberSystem) % 10] : (char)((number % numberSystem) + '0');
                number /= numberSystem;
                answer = remainder.ToString() + answer;
            }

            return answer;
        }
    }
}
