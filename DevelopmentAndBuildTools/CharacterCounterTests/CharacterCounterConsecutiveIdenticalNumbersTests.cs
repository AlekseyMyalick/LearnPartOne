using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentAndBuildTools.Tests
{
    [TestClass()]
    public class CharacterCounterConsecutiveIdenticalNumbersTests
    {
        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_Null_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_EmptyString_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(null);

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_WhiteSpaces_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers("     ");

            Assert.AreEqual(0, actual);
        }

        [TestMethod()]
        [DataRow("1111[bc5ed/223f", 4)]
        [DataRow("b8111e@drf98888.", 4)]
        [DataRow("..b555]e7777dr*rf", 4)]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_Maximum_ReturnsZero(string value, int expected)
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(value);

            Assert.AreEqual(expected, actual);
        }

        private CharacterCounter CreateDefaultCharacterCounter()
        {
            return new CharacterCounter();
        }
    }
}
