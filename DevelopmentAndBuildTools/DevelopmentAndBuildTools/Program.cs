using System;

namespace DevelopmentAndBuildTools
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = MaximumNumberUnequalConsecutiveCharacters(args[0]);
            Console.WriteLine(result);
        }

        static int MaximumNumberUnequalConsecutiveCharacters(string characterSet)
        {
            if (string.IsNullOrEmpty(characterSet))
            {
                return 0;
            }

            int result = 1, count = 1;

            for (int i = 0; i < characterSet.Length - 1; i++)
            {
                if (characterSet[i].CompareTo(characterSet[i + 1]) != 0)
                {
                    count++;
                }

                else
                {
                    result = count > result ? count : result;
                    count = 1;
                }
            }

            return count > result ? count : result;
        }
    }
}
