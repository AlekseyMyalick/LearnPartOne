using System;

namespace DevelopmentAndBuildTools
{
    public class CharacterCounter
    {
        /// <summary>
        /// Returns the maximum number of unequal consecutive characters in a string.
        /// </summary>
        /// <param name="characterSet">The string to count.</param>
        /// <returns>0 if the string is empty, otherwise the maximum number.</returns>
        public int GetMaximumNumberUnequalConsecutiveCharacters(string characterSet)
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

        /// <summary>
        /// Returns the maximum number of consecutive 
        /// identical letters of the Latin alphabet in a string
        /// </summary>
        /// <param name="characterSet">The string to count.</param>
        /// <returns>0 if the string is empty, otherwise the maximum number.</returns>
        public int GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(string characterSet)
        {
            if (string.IsNullOrEmpty(characterSet))
            {
                return 0;
            }

            int result = 0;
            int count = 0;

            for (int i = 0; i < characterSet.Length - 1; i++)
            {
                if (IsLatinAlphabetLetter(characterSet[i]) && count == 0)
                {
                    count = 1;
                }

                if (IsLatinAlphabetLetter(characterSet[i]) && 
                    characterSet[i].CompareTo(characterSet[i + 1]) == 0)
                {
                    count++;
                }
                else
                {
                    result = GetMaximum(count, result);
                    count = 0;
                }
            }

            return GetMaximum(count, result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterSet"></param>
        /// <returns></returns>
        public int GetMaximumNumberConsecutiveIdenticalNumbers(string characterSet)
        {
            if (string.IsNullOrEmpty(characterSet))
            {
                return 0;
            }

            int result = 0;
            int count = 0;

            for (int i = 0; i < characterSet.Length - 1; i++)
            {
                if (char.IsDigit(characterSet[i]) && count == 0)
                {
                    count = 1;
                }

                if (char.IsDigit(characterSet[i]) &&
                    characterSet[i].CompareTo(characterSet[i + 1]) == 0)
                {
                    count++;
                }
                else
                {
                    result = GetMaximum(count, result);
                    count = 0;
                }
            }

            return GetMaximum(count, result);
        }

        /// <summary>
        /// Checks if a character is a Latin letter.
        /// </summary>
        /// <param name="symbol">Check symbol.</param>
        /// <returns>True if the character is a letter of the 
        /// Latin alphabet, otherwise false</returns>
        private bool IsLatinAlphabetLetter(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'a') ||
                (symbol >= 'a' && symbol <= 'z');
        }

        /// <summary>
        /// Returns a maximum of two numbers.
        /// </summary>
        /// <param name="a">First number to compare.</param>
        /// <param name="b">Second number for comparison.</param>
        /// <returns>Larger number.</returns>
        private int GetMaximum(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
