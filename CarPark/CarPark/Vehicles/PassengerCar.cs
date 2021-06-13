using System;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a passenger car.
    /// </summary>
    [Serializable]
    public class PassengerCar : Vehicle
    {
        /// <summary>
        /// Represents the number of doors.
        /// </summary>
        public byte DoorsCount { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public PassengerCar() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a PassengerCar-type object.</param>
        /// <param name="chassis">Chassis of a PassengerCar-type object.</param>
        /// <param name="transmission">Transmission of a PassengerCar-type object.</param>
        /// <param name="doorsCount">Number of doors of a PassengerCar-type object.</param>
        public PassengerCar (Engine engine, Chassis chassis, Transmission transmission, byte doorsCount) 
            : base(engine, chassis, transmission)
        {
            DoorsCount = doorsCount;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Doors count: {DoorsCount}\n";
        }
    }
}
