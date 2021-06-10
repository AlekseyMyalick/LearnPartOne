using System;

namespace InterfacesAndAbstractClasses
{
    public struct Coordinate
    {
        private double _x;
        private double _y;
        private double _z;
        
        public Coordinate (double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public double Distance(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow((coordinate._x - _x), 2) + 
                Math.Pow((coordinate._y - _y), 2) +
                Math.Pow((coordinate._z - _z), 2));
        }
    }
}
