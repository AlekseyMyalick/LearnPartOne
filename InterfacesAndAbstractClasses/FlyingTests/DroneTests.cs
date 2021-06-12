using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingTests
{
    [TestClass]
    public class DroneTests
    {
        private Drone _drone;

        [TestInitialize]
        public void DroneInitialize()
        {
            _drone = new Drone(new Coordinate(0, 0, 0), 1);
        }

        [TestMethod]
        public void FlyTo_ZeroDistance_ReturnTrue()
        {
            Assert.IsTrue(_drone.FlyTo(new Coordinate(0, 0, 0)));
        }

        [TestMethod]
        public void FlyTo_DistanceMoreThanMax_ReturnFalse()
        {
            Assert.IsFalse(_drone.FlyTo(new Coordinate(1000, 1000, 1000)));
        }

        [TestMethod]
        public void FlyTo_CorrectDistanse_ReturnTrue()
        {
            Assert.IsTrue(_drone.FlyTo(new Coordinate(10, 10, 10)));
        }

        [TestMethod]
        public void GetFlyTime_ZeroDistance_ReturnZero()
        {
            Assert.AreEqual(_drone.GetFlyTime(new Coordinate(0, 0, 0)), TimeSpan.Parse("0"));
        }

        [TestMethod]
        public void GetFlyTime_DistanceMoreThanMax_ReturnTimeSpanMaxValue()
        {
            Assert.AreEqual(_drone.GetFlyTime(new Coordinate(1000, 1000, 1000)), TimeSpan.MaxValue);
        }

        [TestMethod]
        public void GetFlyTime_CorrectDistance_ReturnTrue()
        {
            Assert.AreEqual(_drone.GetFlyTime(new Coordinate(10, 10, 10)), TimeSpan.Parse("03:27:50.7658144"));
        }

    }
}
