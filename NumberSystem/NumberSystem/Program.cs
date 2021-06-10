using System;

namespace NumberSystem
{
    public class Program
    {

        public static void Main(string[] args)
        {
            try
            {
                string result = Converter.Convert(int.Parse(args[0]), int.Parse(args[1]));
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
