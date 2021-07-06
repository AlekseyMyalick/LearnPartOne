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
        public void GetMaximumNumberConsecutiveIdenticalNumbers_Maximum_ReturnsCorrectResults(string value, int expected)
        {
            CharacterCounter characterCounter = CreateDefaultCharacterCounter();

            int actual = characterCounter.GetMaximumNumberConsecutiveIdenticalNumbers(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(",l;fgbl;s;';'pfrpsmmovfldfvv6d6f65h4934)@##%HNKJgknf$#$(V646fGNKh^UWkmlc9ewjjjjdfvkkan24sYEWbmlWYE%^@" +
            "kjdfnvloikllkk kl;afd e684e84NLFV635456%#^&(lkd;;;sf;ew^^@%#()glnldfvkl;;kkkkkkkkkkkkksdvlasdv666892689265" +
            "dfvnokdrv;wiefmmkusdc;'d[7%^%# rf;lkllawikmjh4%%#^$@_169dRGJNHJE%#()$)(Yjhjds%&*(bhjsdc557965kfvksdhkmkl##" +
            "afvkksklfjb&^&*(Thldfvf4564hllsllkln$(#@)U*^(hnjdfvfsvhv64648963dkkksdjkhkbbjhT^&*((T#bkjsdcgjbksugzj    e" +
            "dfvklndfvf1v64ds67r*435/6y767r974x63rf8697sg216s9g733sdsvbkjkjfhkmse;ocnvhsejfkbvnad58efvhje6$^*%@#@$)kdfd", 3)]
        public void GetMaximumNumberConsecutiveIdenticalNumbers_LongString_ReturnsCorrectResults(string value, int expected)
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
