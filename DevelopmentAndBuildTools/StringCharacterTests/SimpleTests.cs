using NUnit.Framework;
using DevelopmentAndBuildTools;

namespace StringCharacterTests
{
    [TestFixture]
    public class SimpleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MaximumNumberUnequalConsecutiveCharacters_Null_ReturnZero()
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters(null), 0);
        }

        [Test]
        public void MaximumNumberUnequalConsecutiveCharacters_StringEmpty_ReturnZero()
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters(string.Empty), 0);
        }

        [Test]
        public void MaximumNumberUnequalConsecutiveCharacters_WhiteSpace_ReturnOne()
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters("     "), 1);
        }

        [Test]
        [TestCase("aaa")]
        [TestCase("AAA")]
        [TestCase("   ")]
        [TestCase("]]]")]
        public void MaximumNumberUnequalConsecutiveCharacters_IdenticalSymbols_ReturnOne(string value)
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters(value), 1);
        }

        [Test]
        [TestCase("aAa", 3)]
        [TestCase("aAAAaa", 2)]
        [TestCase("aaaAAAA", 2)]
        public void MaximumNumberUnequalConsecutiveCharacters_RegistersDifference(string value, int expected)
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters(value), expected );
        }

        [Test]
        [TestCase("alnk1gggth4jelle;ww6w", 7)]
        [TestCase("    ff", 2)]
        [TestCase("ff    ", 2)]
        [TestCase("  dfdf  ", 6)]
        public void MaximumNumberUnequalConsecutiveCharacters_True(string value, int expected)
        {
            Assert.AreEqual(Program.MaximumNumberUnequalConsecutiveCharacters(value), expected);
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        public void Maximum_ReturnTrue(int aValue, int bValue, int expected)
        {
            Assert.AreEqual(Program.Maximum(aValue, bValue), expected);
        }
    }
}