using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingTests
{
    [TestClass]
    public class BirdTests
    {
        private Bird bird;

        [TestInitialize]
        public void BirdInitialize()
        {
            bird = new Bird(new Coordinate(0, 0, 0));
        }

        [TestMethod]
        public void FlyTo_ZeroSpeed_ReturnFalse()
        {
            bird.Speed = 0;
            Assert.IsFalse(bird.FlyTo(new Coordinate(10, 10, 10)));
        }

        [TestMethod]
        public void FlyTo_DistanceMoreThanMax_ReturnFalse()
        {
            bird.Speed = 10;
            Assert.IsFalse(bird.FlyTo(new Coordinate(100, 100, 100)));
        }

        [TestMethod]
        public void FlyTo_CorrectSpeedAndDistance_ReturnTrue()
        {
            bird.Speed = 10;
            Assert.IsTrue(bird.FlyTo(new Coordinate(10, 10, 10)));
        }

        [TestMethod]
        public void GetFlyTime_ZeroSpeed_ReturnTimeSpanMaxValue()
        {
            bird.Speed = 0;
            Assert.AreEqual(bird.GetFlyTime(new Coordinate(10, 10, 10)), TimeSpan.MaxValue);
        }

        [TestMethod]
        public void GetFlyTime_DistanceMoreThanMax_ReturnTimeSpanMaxValue()
        {
            bird.Speed = 10;
            Assert.AreEqual(bird.GetFlyTime(new Coordinate(100, 100, 100)), TimeSpan.MaxValue);
        }

        [TestMethod]
        public void GetFlyTime_CorrectSpeedAndDistance_ReturnTrue()
        {
            bird.Speed = 10;
            Assert.AreEqual(bird.GetFlyTime(new Coordinate(10, 10, 10)), TimeSpan.Parse("01:43:55.3829072"));
        }

        [TestMethod]
        public void GetFlyTime_ZeroDistance_ReturnZero()
        {
            bird.Speed = 10;
            Assert.AreEqual(bird.GetFlyTime(new Coordinate(0, 0, 0)), TimeSpan.Parse("0"));
        }
    }
}
