using System;

namespace InterfacesAndAbstractClasses
{
    public static class Randomizer
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);

        public static int GeneratesRandomSpeed(int start, int end)
        {
            return random.Next(start, end);
        }
    }
}
