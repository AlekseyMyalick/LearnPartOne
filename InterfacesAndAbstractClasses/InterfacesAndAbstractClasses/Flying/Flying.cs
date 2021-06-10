namespace InterfacesAndAbstractClasses
{
    public abstract class Flying
    {
        public Coordinate CurrentPosition { get; set; }

        /// <summary>
        /// Creates an object at the current coordinate.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        public Flying (Coordinate currentPosition)
        {
            CurrentPosition = currentPosition;
        }
    }
}
