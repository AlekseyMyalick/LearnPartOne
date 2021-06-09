using System;

namespace DevelopmentAndBuildTools
{
    class Program
    {
        static void Main(string[] args)
        {
            string characterSet = GetFirstArgument(args);
            int result = MaximumNumberUnequalConsecutiveCharacters(characterSet);
            Console.WriteLine(result);
        }

        static int MaximumNumberUnequalConsecutiveCharacters(string characterSet) 
        {
            if (string.IsNullOrEmpty(characterSet))
            {
                return 0;
            }

            int result = 1;
            int count = 1;

            for (int i = 0; i < characterSet.Length - 1; i++)
            {
                if (characterSet[i].CompareTo(characterSet[i + 1]) != 0)
                {
                    count++;
                }
                else
                {
                    result = Maximum(count, result);
                    count = 1;
                }
            }

            return Maximum(count, result);
        }

        static string GetFirstArgument(string[] args)
        {
            if (args.Length == 0)
            {
                return null;
            }

            return args[0];
        }

        static int Maximum(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
