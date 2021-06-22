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
        private static int _id = 1;

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
        /// Represents ID.
        /// </summary>
        public int Id { get; protected set; }

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
            Id = _id++;
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
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type Vehicle and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var vehicle = obj as Vehicle;

            return VehicleEngine.Equals(vehicle.VehicleEngine) &&
                VehicleChassis.Equals(vehicle.VehicleChassis) &&
                VehicleTransmission.Equals(vehicle.VehicleTransmission);
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        protected bool IsValidVehicle()
        {
            return !(VehicleEngine is null || VehicleChassis is null || VehicleTransmission is null); 
        }
    }
}
