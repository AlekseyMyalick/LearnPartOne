using System;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a truck.
    /// </summary>
    [Serializable]
    public class Truck : Vehicle
    {
        /// <summary>
        /// Maximum speed, measured in kilohm meters per hour.
        /// </summary>
        private double _maxSpeed;

        /// <summary>
        /// Represents the maximum speed, measured in kilometers per hour.
        /// </summary>
        public double MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                if (_maxSpeed < 0)
                {
                    throw new ArgumentOutOfRangeException("The maximum speed cannot be less than zero.");
                }
                else
                {
                    _maxSpeed = value;
                }
            }
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Truck() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a Truck-type object.</param>
        /// <param name="chassis">Chassis of a Truck-type object.</param>
        /// <param name="transmission">Transmission of a Truck-type object.</param>
        /// <param name="maxSpeed">Max speed of a Truck-type object.</param>
        public Truck (Engine engine, Chassis chassis, Transmission transmission, double maxSpeed)
            : base(engine, chassis, transmission)
        {
            MaxSpeed = maxSpeed;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Max speed: {MaxSpeed}\n";
        }
    }
}
