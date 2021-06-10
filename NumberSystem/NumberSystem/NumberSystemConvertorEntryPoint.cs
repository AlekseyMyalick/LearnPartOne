using System;

namespace NumberSystem
{
    public class NumberSystemConvertorEntryPoint
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid number of arguments.");
            }
            else
            {
                try
                {
                    string result = NumberSystemConvertor.Convert(int.Parse(args[0]), int.Parse(args[1]));
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
