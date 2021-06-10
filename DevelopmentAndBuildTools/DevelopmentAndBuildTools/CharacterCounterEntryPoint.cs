using System;

namespace DevelopmentAndBuildTools
{
    public class CharacterCounterEntryPoint
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid number of arguments");
            }
            else
            {
                int result = MaximumNumberUnequalConsecutiveCharacters(args[0]);
                Console.WriteLine(result);
            }
        }

        public static int MaximumNumberUnequalConsecutiveCharacters(string characterSet) 
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

        public static int Maximum(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
