namespace InterfacesAndAbstractClasses
{
    public class Bird : Flying, IFlyable
    {
        private const int _minSpeed = 0;
        private const int _maxSpeed = 20;

        /// <summary>
        /// Measured in km.
        /// </summary>
        private const int _maxDistance = 150;

        /// <summary>
        /// Measured in km/h.
        /// </summary>
        public int Speed { get; set; }

        public Bird (Coordinate currentPosition) : base(currentPosition)
        {
            Speed = Randomizer.GeneratesRandomSpeed(_minSpeed, _maxSpeed);
        }

        /// <summary>
        /// Distance cannot exceed _maxDistance.
        /// </summary>
        /// <param name="newCoordinate">Path end coordinates.</param>
        /// <returns>will it fly</returns>
        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return Speed != 0 && distance < _maxDistance;
        }

        public double GetFlyTime(Coordinate newCoordinate)
        {
            if (FlyTo(newCoordinate))
            {
                double distance = CurrentPosition.Distance(newCoordinate);

                return distance / Speed;
            }
            else
            {
                return double.PositiveInfinity;
            }           
        }
    }
}
