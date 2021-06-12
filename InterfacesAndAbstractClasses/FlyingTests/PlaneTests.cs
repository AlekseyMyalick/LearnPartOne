using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;
using System;

namespace FlyingTests
{
    [TestClass]
    public class PlaneTests
    {
        private Plane _plane;

        [TestInitialize]
        public void PleneInitialize()
        {
            _plane = new Plane(new Coordinate(0, 0, 0), 0); 
        }

        [TestMethod]
        public void FlyTo_ZeroFuelVolume_ReturnFalse()
        {
            _plane.FuelVolume = 0;
            Assert.IsFalse(_plane.FlyTo(new Coordinate(10, 10, 10)));
        }

        [TestMethod]
        public void FlyTo_CorrectFuelVolume_ReturnTrue()
        {
            _plane.FuelVolume = 2000;
            Assert.IsTrue(_plane.FlyTo(new Coordinate(10, 10, 10)));
        }

        [TestMethod]
        public void GetFlyTime_ZeroFuelVolime_ReturnTimeSpanMaxValue()
        {
            _plane.FuelVolume = 0;
            Assert.AreEqual(_plane.GetFlyTime(new Coordinate(100, 100, 100)), TimeSpan.MaxValue);
        }

        [TestMethod]
        public void GetFlyTime_ZeroDistance_ReturnZero()
        {
            _plane.FuelVolume = 2000;
            Assert.AreEqual(_plane.GetFlyTime(new Coordinate(0, 0, 0)), TimeSpan.Parse("0"));
        }

        [TestMethod]
        public void GetFlyTime_CorrectDistance_ReturnTrue()
        {
            _plane.FuelVolume = 2000;
            Assert.AreEqual(_plane.GetFlyTime(new Coordinate(100, 100, 100)), TimeSpan.Parse("05:22:43.9374379"));
        }

        [TestMethod]
        [DataRow(100, 100, 100, 380)]
        [DataRow(200, 200, 200, 550)]
        [DataRow(500, 500, 500, 1070)]
        [DataRow(720, 720, 720, 1450)]
        public void CorrectSpeedGrowth(int xValue, int yValue, int zValue, int expectedSpeed)
        {
            _plane.FuelVolume = 2000;
            _plane.GetFlyTime(new Coordinate(xValue, yValue, zValue));
            Assert.AreEqual(_plane.Speed, expectedSpeed);
        }
    }
}
