using System;

namespace InterfacesAndAbstractClasses
{
    struct Coordinate
    {
        public double x;
        public double y;
        public double z;
        
        public Coordinate (double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Distance(Coordinate coordinate)
        {
            return Math.Sqrt(Math.Pow((coordinate.x - x), 2)
                           + Math.Pow((coordinate.y - y), 2)
                           + Math.Pow((coordinate.z - z), 2));
        }
    }
}
