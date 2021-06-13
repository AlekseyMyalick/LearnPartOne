using System;

namespace CarPark.Models
{
    /// <summary>
    /// Represents a model with methods from different entities.
    /// </summary>
    [Serializable]
    public class VehicleModel
    {
        /// <summary>
        /// Engine's type.
        /// </summary>
        public EngineType Type { get; set; }

        /// <summary>
        /// Serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Power.
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public VehicleModel() { }

        /// <summary>
        /// Initializes fields.
        /// </summary>
        /// <param name="type">The engine type of the class object.</param>
        /// <param name="serialNumber">The serial number of the class object.</param>
        /// <param name="power">The power of the class object.</param>
        public VehicleModel (EngineType type, string serialNumber, double power)
        {
            Type = type;
            SerialNumber = serialNumber;
            Power = power;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return $"Engine type: {Type} \nSerial number: {SerialNumber} \nPower: {Power} hp \n";
        }
    }
}
