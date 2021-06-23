using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentAndBuildTools.Tests
{
    [TestClass()]
    public class CharacterCounterTests
    {
        [TestMethod()]
        public void GetMaximumNumberUnequalConsecutiveCharacters_Null_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberUnequalConsecutiveCharacters_EmptyString_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters(string.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        [DataRow("aaaabcedrf", 4)]
        [DataRow("bcedrfaaaa", 4)]
        [DataRow("bceaaaadrf", 4)]
        public void GetMaximumNumberUnequalConsecutiveCharacters_EdgeValues_ReturnsCorrectResults(string value, int expected)
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberUnequalConsecutiveCharacters_WhiteSpaces_ReturnsOne()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters("     ");

            Assert.AreEqual(1, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_Null_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_EmptyString_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(string.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_Null_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_EmptyString_ReturnsZero()
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(null);

            Assert.AreEqual(0, actual);
        }
    }
}