using System;

namespace InterfacesAndAbstractClasses
{
    interface IFlyable
    {
        bool FlyTo(Coordinate newCoordinate);

        TimeSpan GetFlyTime(Coordinate newCoordinate);
    }
}
