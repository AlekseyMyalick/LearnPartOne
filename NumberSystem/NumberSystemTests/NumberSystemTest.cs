using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSystem;
using System;

namespace NumberSystemTests
{
    [TestClass]
    public class NumberSystemTest
    {
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 21)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Converter_ArgumentOutOfRangeException(int numberValue, int numberSystemValue)
        {
            string actual = NumberSystemConvertor.Convert(numberValue, numberSystemValue);
        }

        [TestMethod]
        [DataRow(10, 2, "1010")]
        [DataRow(10, 3, "101")]
        [DataRow(10, 4, "22")]
        [DataRow(10, 5, "20")]
        [DataRow(10, 6, "14")]
        [DataRow(10, 7, "13")]
        [DataRow(10, 8, "12")]
        [DataRow(10, 9, "11")]
        [DataRow(10, 10, "10")]
        [DataRow(110, 11, "A0")]
        [DataRow(110, 12, "92")]
        [DataRow(114, 13, "8A")]
        [DataRow(292, 14, "16C")]
        [DataRow(478, 15, "21D")]
        [DataRow(478, 16, "1DE")]
        [DataRow(478, 17, "1B2")]
        [DataRow(15478, 18, "2BDG")]
        [DataRow(15478, 19, "24GC")]
        [DataRow(15478, 20, "1IDI")]
        [DataRow(19, 20, "J")]
        public void Converter_PositiveNumbers_ReturnTrue(int numberValue, int numberSystemValue, string expected)
        {
            Assert.AreEqual(NumberSystemConvertor.Convert(numberValue, numberSystemValue), expected);
        }

        [TestMethod]
        [DataRow(-10, 2, "-1010")]
        [DataRow(-10, 3, "-101")]
        [DataRow(-10, 4, "-22")]
        [DataRow(-10, 5, "-20")]
        [DataRow(-10, 6, "-14")]
        [DataRow(-10, 7, "-13")]
        [DataRow(-10, 8, "-12")]
        [DataRow(-10, 9, "-11")]
        [DataRow(-10, 10, "-10")]
        [DataRow(-110, 11, "-A0")]
        [DataRow(-110, 12, "-92")]
        [DataRow(-114, 13, "-8A")]
        [DataRow(-292, 14, "-16C")]
        [DataRow(-478, 15, "-21D")]
        [DataRow(-478, 16, "-1DE")]
        [DataRow(-478, 17, "-1B2")]
        [DataRow(-15478, 18, "-2BDG")]
        [DataRow(-15478, 19, "-24GC")]
        [DataRow(-15478, 20, "-1IDI")]
        [DataRow(-19, 20, "-J")]
        public void Converter_NegativeNumbers_ReturnTrue(int numberValue, int numberSystemValue, string expected)
        {
            Assert.AreEqual(NumberSystemConvertor.Convert(numberValue, numberSystemValue), expected);
        }

        [TestMethod]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(11)]
        [DataRow(12)]
        [DataRow(13)]
        [DataRow(14)]
        [DataRow(15)]
        [DataRow(16)]
        [DataRow(17)]
        [DataRow(18)]
        [DataRow(19)]
        [DataRow(20)]
        public void Converter_Zero_ReturnTrue(int numberSystemValue)
        {
            Assert.AreEqual(NumberSystemConvertor.Convert(0, numberSystemValue), "0");
        }

        [TestMethod]
        [DataRow(10, 11, "A")]
        [DataRow(11, 12, "B")]
        [DataRow(12, 13, "C")]
        [DataRow(13, 14, "D")]
        [DataRow(14, 15, "E")]
        [DataRow(15, 16, "F")]
        [DataRow(16, 17, "G")]
        [DataRow(17, 18, "H")]
        [DataRow(18, 19, "I")]
        [DataRow(19, 20, "J")]
        public void Converter_CheckingTheAlphabetContent(int numberValue, int numberSystemValue, string expected)
        {
            Assert.AreEqual(NumberSystemConvertor.Convert(numberValue, numberSystemValue), expected);
        }

        [TestMethod]
        [DataRow(2, "1111111111111111111111111111111")]
        [DataRow(3, "12112122212110202101")]
        [DataRow(4, "1333333333333333")]
        [DataRow(5, "13344223434042")]
        [DataRow(6, "553032005531")]
        [DataRow(7, "104134211161")]
        [DataRow(8, "17777777777")]
        [DataRow(9, "5478773671")]
        [DataRow(10, "2147483647")]
        [DataRow(11, "A02220281")]
        [DataRow(12, "4BB2308A7")]
        [DataRow(13, "282BA4AAA")]
        [DataRow(14, "1652CA931")]
        [DataRow(15, "C87E66B7")]
        [DataRow(16, "7FFFFFFF")]
        [DataRow(17, "53G7F548")]
        [DataRow(18, "3928G3H1")]
        [DataRow(19, "27C57H32")]
        [DataRow(20, "1DB1F927")]
        public void Converter_MaxValue_ReturnTrue(int numberSystemValue, string expected)
        {
            Assert.AreEqual(NumberSystemConvertor.Convert(int.MaxValue, numberSystemValue), expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Converter_MinValue_ArgumentOutOfRangeException()
        {
            string actual = NumberSystemConvertor.Convert(int.MinValue, 2);
        }
    }
}
