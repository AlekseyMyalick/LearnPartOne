using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfacesAndAbstractClasses;

namespace FlyingTests
{
    [TestClass]
    public class CoordinateTests
    {
        private Coordinate _startCoordinate;

        [TestInitialize]
        public void CoordinateInitialize()
        {
            _startCoordinate = new Coordinate(0, 0, 0);
        }

        [TestMethod]
        public void Distance_IdenticalCoordinate_ReturnZero()
        {
            Assert.AreEqual(_startCoordinate.Distance(new Coordinate(0, 0, 0)), 0);
        }

        [TestMethod]
        public void Distance_EndCoordinateGreaterThanStart_ReruenTrue()
        {
            Assert.AreEqual(_startCoordinate.Distance(new Coordinate(10, 10, 10)), 17.320508075688775d);
        }

        [TestMethod]
        public void Distance_EndCoordinateLessThanStart_ReruenTrue()
        {
            Assert.AreEqual(_startCoordinate.Distance(new Coordinate(-10, -10, -10)), 17.320508075688775d);
        }

        [TestMethod]
        public void Distance_MaxAndMinValue_ReruenTrue()
        {
            Coordinate firstCoordinate = new Coordinate(int.MinValue, int.MinValue, int.MinValue);
            Coordinate secondCoordinate = new Coordinate(int.MaxValue, int.MaxValue, int.MaxValue);

            Assert.AreEqual(secondCoordinate.Distance(firstCoordinate), 7439101571.786667d);
        }

        [TestMethod]
        public void Distance_MinAndMaxValue_ReruenTrue()
        {
            Coordinate firstCoordinate = new Coordinate(int.MinValue, int.MinValue, int.MinValue);
            Coordinate secondCoordinate = new Coordinate(int.MaxValue, int.MaxValue, int.MaxValue);

            Assert.AreEqual(firstCoordinate.Distance(secondCoordinate), 7439101571.786667d);
        }
    }
}
