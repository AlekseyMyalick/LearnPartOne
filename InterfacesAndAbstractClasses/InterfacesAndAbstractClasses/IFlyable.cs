using System;

namespace InterfacesAndAbstractClasses
{
    interface IFlyable
    {
        bool FlyTo(Coordinate newCoordinate);

        DateTime GetFlyTime(Coordinate newCoordinate);
    }
}
