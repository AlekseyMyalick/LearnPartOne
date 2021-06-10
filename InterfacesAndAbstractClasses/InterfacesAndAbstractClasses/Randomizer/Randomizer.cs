using System;

namespace InterfacesAndAbstractClasses
{
    public static class Randomizer
    {
        private static readonly Random random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Generates a random number from start to end.
        /// </summary>
        /// <param name="start">The minimum value of the range.</param>
        /// <param name="end">The maximum value of the range.</param>
        /// <returns>Random number from start to end.</returns>
        public static int GeneratesRandomSpeed(int start, int end)
        {
            return random.Next(start, end);
        }
    }
}
