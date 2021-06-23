using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentAndBuildTools
{
    public class CharacterCounter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterSet"></param>
        /// <returns></returns>
        public static int GetMaximumNumberUnequalConsecutiveCharacters(string characterSet)
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
                    result = GetMaximum(count, result);
                    count = 1;
                }
            }

            return GetMaximum(count, result);
        }


        public static int GetMaximum(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
