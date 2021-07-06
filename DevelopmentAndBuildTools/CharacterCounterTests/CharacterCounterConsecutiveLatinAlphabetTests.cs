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
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_WhiteSpaces_ReturnsZero()
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters("      ");

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

        [TestMethod()]
        [DataRow(",l;fgbl;s;';'pfrpsmmovfldfvv6d6f65h4934)@##%HNKJgknf$#$(V646fGNKh^UWkmlc9ewjjjjdfvkkan24sYEWbmlWYE%^@" +
            "kjdfnvloikllkk kl;afd e684e84NLFV635456%#^&(lkd;;;sf;ew^^@%#()glnldfvkl;;kkkkkkkkkkkkksdvlasdv666892689265" +
            "dfvnokdrv;wiefmmkusdc;'d[7%^%# rf;lkllawikmjh4%%#^$@_169dRGJNHJE%#()$)(Yjhjds%&*(bhjsdc557965kfvksdhkmkl##" +
            "afvkksklfjb&^&*(Thldfvf4564hllsllkln$(#@)U*^(hnjdfvfsvhv64648963dkkksdjkhkbbjhT^&*((T#bkjsdcgjbksugzj    e" +
            "dfvklndfvf1v64ds67r*435/6y767r974x63rf8697sg216s9g733sdsvbkjkjfhkmse;ocnvhsejfkbvnad58efvhje6$^*%@#@$)kdfd", 13)]
        public void GetMaximumNumberConsecutiveIdenticalLatinAlphabetLetters_LongString_ReturnsCorrectResults(string value, int expected)
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
