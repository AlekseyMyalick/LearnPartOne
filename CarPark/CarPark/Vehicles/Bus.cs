using System;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a bus.
    /// </summary>
    [Serializable]
    public class Bus : Vehicle
    {
        /// <summary>
        /// Represents the number of seats.
        /// </summary>
        public byte SeatsCount { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Bus() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a Bus-type object.</param>
        /// <param name="chassis">Chassis of a Bus-type object.</param>
        /// <param name="transmission">Transmission of a Bus-type object.</param>
        /// <param name="seatsCount">The number of seats of the object of the Bus type.</param>
        public Bus (Engine engine, Chassis chassis, Transmission transmission, byte seatsCount)
            : base(engine, chassis, transmission)
        {
            SeatsCount = seatsCount;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Seats count: {SeatsCount}\n";
        }
    }
}
