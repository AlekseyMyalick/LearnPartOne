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

        private CharacterCounter CreateDefaultCharacterCounter()
        {
            return new CharacterCounter();
        }
    }
}
