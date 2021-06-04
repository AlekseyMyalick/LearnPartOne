namespace InterfacesAndAbstractClasses
{
    public abstract class Flying
    {
        public Coordinate CurrentPosition { get; set; }

        public Flying (Coordinate currentPosition)
        {
            CurrentPosition = currentPosition;
        }
    }
}
