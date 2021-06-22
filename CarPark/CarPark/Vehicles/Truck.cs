using System;
using CarPark.Exceptions;

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
        private const double _maxSpeed = 200;

        /// <summary>
        /// Minimum speed, measured in kilohm meters per hour.
        /// </summary>
        private const double _minSpeed = 0;

        /// <summary>
        /// Represents the maximum speed, measured in kilometers per hour.
        /// </summary>
        public double MaxSpeed { get; set; }

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

            if (!IsValidTruck())
            {
                throw new InitializationException("Unable to initialize the Truck.");
            }
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Max speed: {MaxSpeed}\n";
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        private bool IsValidTruck()
        {
            return IsValidVehicle() && MaxSpeed > _minSpeed && MaxSpeed <= _maxSpeed;
        }
    }
}
