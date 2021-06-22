using System;
using System.Xml.Serialization;

namespace CarPark
{
    /// <summary>
    /// Represents an abstract class vehicle.
    /// </summary>
    [XmlInclude(typeof(PassengerCar))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Bus))]
    [XmlInclude(typeof(Scooter))]
    [Serializable]
    public abstract class Vehicle
    {
        /// <summary>
        /// Represents the engine.
        /// </summary>
        public Engine VehicleEngine { get; set; }

        /// <summary>
        /// Represents the chassis.
        /// </summary>
        public Chassis VehicleChassis { get; set; }

        /// <summary>
        /// Represents the transmission.
        /// </summary>
        public Transmission VehicleTransmission { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Vehicle() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a Vehicle-type object.</param>
        /// <param name="chassis">Chassis of a Vehicle-type object.</param>
        /// <param name="transmission">Transmission of a Vehicle-type object.</param>
        public Vehicle (Engine engine, Chassis chassis, Transmission transmission)
        {
            VehicleEngine = engine;
            VehicleChassis = chassis;
            VehicleTransmission = transmission;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return $"Engine:\n{VehicleEngine}\nChassis:\n{VehicleChassis}\nTransmission:\n{VehicleTransmission}\n";
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        private bool IsValidVehicle()
        {
            return !(VehicleEngine is null || VehicleChassis is null || VehicleTransmission is null); 
        }
    }
}
