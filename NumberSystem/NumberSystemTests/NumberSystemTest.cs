using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberSystem;
using System;

namespace NumberSystemTests
{
    [TestClass]
    public class NumberSystemTest
    {
        [TestMethod]
        [DataRow(5, '5')]
        [DataRow(0, '0')]
        public void ToChar_ReturnTrue(int value, char expected)
        {
            Assert.AreEqual(Converter.ToChar(value), expected);
        }

        [TestMethod]
        [DataRow(-5)]
        [DataRow(10)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ToChar_ArgumentOutOfRangeException(int value)
        {
            char symbol = Converter.ToChar(value);
        }

        [TestMethod]
        [DataRow(-1)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetRemainderSymbol_ArgumentOutOfRangeException(int value)
        {
            char symbol = Converter.GetRemainderSymbol(value);
        }

        [TestMethod]
        [DataRow(10, 'A')]
        [DataRow(11, 'B')]
        [DataRow(12, 'C')]
        [DataRow(13, 'D')]
        [DataRow(14, 'E')]
        [DataRow(15, 'F')]
        [DataRow(16, 'G')]
        [DataRow(17, 'H')]
        [DataRow(18, 'I')]
        [DataRow(19, 'J')]
        public void GetRemainderSymbol_Letters_ReturnTrue(int value, char expected)
        {
            Assert.AreEqual(Converter.GetRemainderSymbol(value), expected);
        }

        [TestMethod]
        [DataRow(0, '0')]
        [DataRow(9, '9')]
        public void GetRemainderSymbol_Numbers_ReturnTrue(int value, char expected)
        {
            Assert.AreEqual(Converter.GetRemainderSymbol(value), expected);
        }

        [TestMethod]
        [DataRow(-4, "-")]
        public void GetNumberSign_RetutnTrue(int value, string expected)
        {
            Assert.AreEqual(Converter.GetNumberSign(value), expected);
        }

        [TestMethod]
        [DataRow(-7, 7)]
        [DataRow(7, 7)]
        public void ChangeNumberSign_ReturnTrue(int value, int expected)
        {
            Converter.ChangeNegativeNumericSign(ref value);
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(10, 21)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Converter_ArgumentOutOfRangeException(int numberValue, int numberSystemValue)
        {
            string actual = Converter.Convert(numberValue, numberSystemValue);
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
            Assert.AreEqual(Converter.Convert(numberValue, numberSystemValue), expected);
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
            Assert.AreEqual(Converter.Convert(numberValue, numberSystemValue), expected);
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
            Assert.AreEqual(Converter.Convert(0, numberSystemValue), "0");
        }
    }
}
