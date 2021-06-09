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
        /// Initializing Class Fields.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        public Bird (Coordinate currentPosition) : base(currentPosition)
        {
            Speed = Randomizer.GeneratesRandomSpeed(_minSpeed, _maxSpeed);
        }

        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return Speed != 0 && distance < _maxDistance;
        }

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
