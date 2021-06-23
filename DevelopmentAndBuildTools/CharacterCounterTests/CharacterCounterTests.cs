﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

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

       
    }
}