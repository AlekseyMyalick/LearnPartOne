using System;

namespace InterfacesAndAbstractClasses
{
    public struct Coordinate
    {
        private double _x;
        private double _y;
        private double _z;

        /// <summary>
        /// Creates a point with a coordinate (X, Y, Z).
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <param name="z">Z coordinate.</param>
        public Coordinate (double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Returns the distance between two points.
        /// </summary>
        /// <param name="coordinate">The coordinate of the end point.></param>
        /// <returns>Distance between two points</returns>
        public double Distance(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow((coordinate._x - _x), 2) + 
                Math.Pow((coordinate._y - _y), 2) +
                Math.Pow((coordinate._z - _z), 2));
        }
    }
}
