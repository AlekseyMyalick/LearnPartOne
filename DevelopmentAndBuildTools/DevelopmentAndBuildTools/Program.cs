using System;

namespace DevelopmentAndBuildTools
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int result = MaximumNumberUnequalConsecutiveCharacters(args[0]);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

        static int Maximum(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
