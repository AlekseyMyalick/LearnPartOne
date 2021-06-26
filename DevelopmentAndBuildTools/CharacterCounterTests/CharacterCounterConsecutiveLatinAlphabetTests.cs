using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentAndBuildTools.Tests
{
    [TestClass()]
    public class CharacterCounterConsecutiveLatinAlphabetTests
    {
        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_Null_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_EmptyString_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(string.Empty);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        [DataRow("aaaa[bc5ed/rrrf", 4)]
        [DataRow("b8ccce@drf9AAAA.", 4)]
        [DataRow("..bccc]eaaaadr*rf", 4)]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_Maximum_ReturnsCorrectResults(string value, int expected)
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters(value);

            Assert.AreEqual(expected, actual);
        }

        private CharacterCounter CreateDefaultCharacterCounter()
        {
            return new CharacterCounter();
        }
    }
}
