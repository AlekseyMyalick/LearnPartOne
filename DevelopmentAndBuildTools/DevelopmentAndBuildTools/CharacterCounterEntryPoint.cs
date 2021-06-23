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
                CharacterCounter counter = new CharacterCounter();
                int result = counter.GetMaximumNumberUnequalConsecutiveCharacters(args[0]);
                Console.WriteLine(result);
            }
        }
    }
}
