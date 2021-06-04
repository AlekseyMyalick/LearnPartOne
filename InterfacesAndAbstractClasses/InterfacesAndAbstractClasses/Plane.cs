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
        /// Fuel consumption per 1000 km.
        /// </summary>
        private const int _fuelConsumption = 1600;

        /// <summary>
        /// Measured in liters.
        /// </summary>
        public double FuelVolume { get; set; }

        /// <summary>
        /// Initializing Class Fields.
        /// </summary>
        /// <param name="currentPosition">Current position.</param>
        /// <param name="fuelVolume">Fuel volume.</param>
        public Plane (Coordinate currentPosition, double fuelVolume) : base(currentPosition)
        {
            FuelVolume = fuelVolume;
        }

        public bool FlyTo(Coordinate newCoordinate)
        {
            double distance = CurrentPosition.Distance(newCoordinate);

            return AmountRequiredFuel(distance) < FuelVolume;
        }

        public double GetFlyTime(Coordinate newCoordinate)
        {
            if (FlyTo(newCoordinate))
            {
                double distance = CurrentPosition.Distance(newCoordinate);

                return TimeCounter(distance);
            }
            else
            {
                return double.PositiveInfinity;
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
            int way = 0;
            int speed = _startSpeed;
            double time = 0;

            while(way < distance)
            {
                way += 10;

                if (speed < _maxSpeed)
                {
                    speed += _acceleration;
                }
                else
                {
                    speed = _maxSpeed;
                }

                time += way / speed;
            }

            if (way > distance)
            {
                time -= (way - distance) / speed;
            }

            return time;
        }
    }
}
