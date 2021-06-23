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
        [DataRow("aaaabcedrf", 7)]
        [DataRow("bcedrfaaaa", 7)]
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
        [DataRow("aaaabcedrrrf", 6)]
        [DataRow("bcccedrfaaaa", 6)]
        [DataRow("bccceaaaadrrf", 3)]
        public void GetMaximumNumberUnequalConsecutiveCharacters_Maximum_ReturnsCorrectResults(string value, int expected)
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("kjnvbgkwjlskjcoislh646vjkdfndfl64864kvnmvmmdfsmv64mdmvkxcnskdcsdkjvmc mxcskjs  slknc " +
            "sdfnlsjcvnlsdvnlskdjvlksdnk lsms efs46ef4sfef4sfseslfksefe  sefsef5s6f3se s sf43 sfes fs s" +
            "sdfsdlnslkdfl sfseesfesf6f5sfsefsef8ggd6gs  sgrd8gd4f   sesfe6fsesefffffdf sef fggggrsg g " +
            "klmlkliounsnnnnnnnn nnnnnnn eeeee   e484844r8 684 68r468468fsgsd gdrg agaagagdfghjfgykamlk" +
            "gsdfgsrg srgsr gsrgsg4sr6g4 6s4rg84 s684rg684r68g46s84g68 es68rg4684rgsrg argajlknfanafjef", 107)]
        public void GetMaximumNumberUnequalConsecutiveCharacters_LongString_ReturnsOne(string value, int expected)
        {
            CharacterCounter characterCounter = new CharacterCounter();

            int actual = characterCounter.GetMaximumNumberUnequalConsecutiveCharacters(value);

            Assert.AreEqual(expected, actual);
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