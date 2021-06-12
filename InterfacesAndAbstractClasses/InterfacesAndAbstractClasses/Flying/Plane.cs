using System;

namespace InterfacesAndAbstractClasses
{
    public class Plane : Flying, IFlyable
    {
        /// <summary>
        /// Initial speed, measured in km/h.
        /// </summary>
        private const int _startSpeed = 200;

        /// <summary>
        /// Maximum speed, measured in km/h.
        /// </summary>
        private const int _maxSpeed = 1500;

        /// <summary>
        /// Acceleration for every 10 km.
        /// </summary>
        private const int _acceleration = 10;

        /// <summary>
        /// Distance Accelerate.
        /// </summary>
        private const int _distanceAccelerate = 10;

        /// <summary>
        /// Fuel consumption per 1000 km.
        /// </summary>
        private const int _fuelConsumption = 1600;

        /// <summary>
        /// Measured in liters.
        /// </summary>
        public double FuelVolume { get; set; }

        /// <summary>
        /// Measured in km/h.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Creates an object at the current coordinate.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        /// <param name="fuelVolume">Fuel volume.</param>
        public Plane (Coordinate currentPosition, double fuelVolume) : base(currentPosition)
        {
            FuelVolume = fuelVolume;
        }

        /// <summary>
        /// Calculates whether it will reach the end point.
        /// </summary>
        /// <param name="newCoordinate">The coordinates of the end point.</param>
        /// <returns>true if it gets there, otherwise false.</returns>
        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return AmountRequiredFuel(distance) < FuelVolume;
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

                return TimeSpan.FromHours(TimeCounter(distance));
            }
            else
            {
                return TimeSpan.MaxValue;
            }
        }

        /// <summary>
        /// Calculates the amount of required fuel based on the distance.
        /// </summary>
        /// <param name="distance">Distance to travel.</param>
        /// <returns>The amount of fuel required.</returns>
        private double AmountRequiredFuel(double distance)
        {
            return distance * _fuelConsumption / 1000;
        }

        /// <summary>
        /// Calculates the time spent on the flight.
        /// </summary>
        /// <param name="distance">Distance to travel.</param>
        /// <returns>Time in hours.</returns>
        private double TimeCounter(double distance)
        {
            double way = 0;
            Speed = _startSpeed;
            double time = 0;

            while(way < distance)
            {
                way += _distanceAccelerate;

                if (Speed < _maxSpeed)
                {
                    Speed += _acceleration;
                }
                else
                {
                    Speed = _maxSpeed;
                }

                time += way / Speed;
            }

            if (way > distance)
            {
                time -= (way - distance) / Speed;
            }

            return time;
        }
    }
}
