using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevelopmentAndBuildTools;

namespace CharacterCounterTests
{
    [TestClass]
    public class CharacterCounterTests
    {
        [TestMethod]
        public void MaximumNumberUnequalConsecutiveCharacters_Null_ReturnZero()
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(null), 0);
        }

        [TestMethod]
        public void MaximumNumberUnequalConsecutiveCharacters_StringEmpty_ReturnZero()
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(string.Empty), 0);
        }

        [TestMethod]
        public void MaximumNumberUnequalConsecutiveCharacters_WhiteSpace_ReturnOne()
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters("     "), 1);
        }

        [TestMethod]
        [DataRow("aaa")]
        [DataRow("222")]
        [DataRow("   ")]
        [DataRow("]]]")]
        public void MaximumNumberUnequalConsecutiveCharacters_IdenticalSymbols_ReturnOne(string value)
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(value), 1);
        }

        /// <summary>
        /// Checks for case insensitivity.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow("aAa", 3)]
        [DataRow("aAAAaa", 2)]
        [DataRow("aaaAAAA", 2)]
        public void MaximumNumberUnequalConsecutiveCharacters_RegistersDifference_ReturnTrue(string value, int expected)
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(value), expected);
        }

        [TestMethod]
        [DataRow("a")]
        [DataRow("1")]
        [DataRow(" ")]
        [DataRow("}")]
        public void MaximumNumberUnequalConsecutiveCharacters_OneSymbol_ReturnTrue(string value)
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(value), 1);
        }

        [TestMethod]
        [DataRow("abgndFF", 6)]
        [DataRow("FFabgnd", 6)]
        [DataRow("abgFFndf", 4)]
        public void MaximumNumberUnequalConsecutiveCharacters_DifferentArrangementIdenticalSymbols_ReturnTrue(string value, int expected)
        {
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(value), expected);
        }

        [TestMethod]
        [DataRow(1, 2, 2)]
        [DataRow(2, 1, 2)]
        [DataRow(2, 2, 2)]
        public void Maximum_ReturnTrue(int aValue, int bValue, int expected)
        {
            Assert.AreEqual(CharacterCounterEntryPoint.Maximum(aValue, bValue), expected);
        }

        [TestMethod]
        public void MaximumNumberUnequalConsecutiveCharacters_LongLine_ReturnTrue()
        {
            string line = "nkjgbnrfvbriubvldkfjbvlurdblbvldfuvhdufvlbdfbvuldf" +
                "uvbldifubvlduifvbdlfbvdflkjvbfyblrdbvflkvmdfvmourfnvdfiuvhdfuhvdnfmfuvhfbvnkmoseifruhg" +
                "lserjfnvmfuvhdfvffvuervhlfkdsfuduyghbgjeiiivisdvolfvfffjijijllllfudddddvbdksfhhrhlvru" +
                "uuuwfennnnnnnvfirbvvvvvrudslkfvnjfdslfjvblweiunfvlrdsivruldvnurrvnlrdiuvnldsifurgnfjvk" +
                "fffffvnldfvnjfkkkkkdlfvnerrlviiiiirnfvliiiiiiibnnnnnnruvldirjnvruuuuuvnldruubvnkldrklvr" +
                "vndlvurfnldfubfvnrivnuldsdurvbruidlfmmmmdlrjvunsrnulufvlrdivrbvldsfnvjruhbvnsdljvfusdll" +
                "llvnruvdlsfvnuslbllvlrsirurv";
            Assert.AreEqual(CharacterCounterEntryPoint.MaximumNumberUnequalConsecutiveCharacters(line), 153);
        }
    }
}
