using System;

namespace InterfacesAndAbstractClasses
{
    public class Bird : Flying, IFlyable
    {
        /// <summary>
        /// Minimum speed, measured in km/h.
        /// </summary>
        private const int _minSpeed = 0;

        /// <summary>
        /// Maximum speed, measured in km/h.
        /// </summary>
        private const int _maxSpeed = 20;

        /// <summary>
        /// Measured in km.
        /// </summary>
        private const int _maxDistance = 150;

        /// <summary>
        /// Measured in km/h.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Creates an object at the current coordinate.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        public Bird (Coordinate currentPosition) : base(currentPosition)
        {
            Speed = Randomizer.GeneratesRandomSpeed(_minSpeed, _maxSpeed);
        }

        /// <summary>
        /// Calculates whether it will reach the end point.
        /// </summary>
        /// <param name="newCoordinate">The coordinates of the end point.</param>
        /// <returns>true if it gets there, otherwise false.</returns>
        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return Speed != 0 && distance < _maxDistance;
        }

        /// <summary>
        /// Calculates the time spent on the flight.
        /// </summary>
        /// <param name="newCoordinate">The coordinates of the end point.</param>
        /// <returns>The time span if it reaches, otherwise infinity.</returns>
        public TimeSpan GetFlyTime(Coordinate newCoordinate)
        {
            if (FlyTo(newCoordinate))
            {
                double distance = CurrentPosition.Distance(newCoordinate);

                return TimeSpan.FromHours(distance / Speed);
            }
            else
            {
                return TimeSpan.MaxValue;
            }           
        }
    }
}
