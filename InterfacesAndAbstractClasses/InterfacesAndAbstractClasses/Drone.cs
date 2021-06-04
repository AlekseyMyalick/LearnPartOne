using System;

namespace InterfacesAndAbstractClasses
{
    public class Drone : Flying, IFlyable
    {
        /// <summary>
        /// Number of stops per hour.
        /// </summary>
        private const double _stopPeriod = 1 / 6;

        /// <summary>
        /// The time at which the drone stops.
        /// </summary>
        private const double _stopTime = 1 / 60;

        /// <summary>
        /// Maximum distance, measured in km.
        /// </summary>
        private const int _maxDistance = 1000;

        /// <summary>
        /// Constant speed of one engine, measured in km/h.
        /// </summary>
        private const int _speed = 5;

        /// <summary>
        /// Drone Engines.
        /// </summary>
        public int EnginesNumber { get; set; }

        /// <summary>
        /// Constant speed, measured in km/h.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Initializing Class Fields.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        /// <param name="engineNumber">Number of engines.</param>
        public Drone(Coordinate currentPosition, int engineNumber) : base(currentPosition)
        {
            EnginesNumber = engineNumber;
            Speed = EnginesNumber * _speed;
        }

        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return distance < _maxDistance;
        }

        public TimeSpan GetFlyTime(Coordinate newCoordinate)
        {
            if (FlyTo(newCoordinate))
            {
                double distance = CurrentPosition.Distance(newCoordinate);

                return TimeSpan.FromHours(TimeCounter(distance));
            }
            else
            {
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Calculates the time spent on the flight.
        /// </summary>
        /// <param name="distance">Distance to travel.</param>
        /// <returns>Time in hours.</returns>
        private double TimeCounter(double distance)
        {
            double nonStopTime = distance / Speed;
            double stopTime = nonStopTime * _stopPeriod * _stopTime;

            return nonStopTime - stopTime;
        }
    }
}
