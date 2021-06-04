namespace InterfacesAndAbstractClasses
{
    interface IFlyable
    {
        bool FlyTo(Coordinate newCoordinate);

        double GetFlyTime(Coordinate newCoordinate);
    }
}
