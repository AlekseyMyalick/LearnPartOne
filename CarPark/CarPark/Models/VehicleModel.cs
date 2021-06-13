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
        public EngineType EngineType { get; set; }

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
        /// <param name="engineType">The engine type of the class object.</param>
        /// <param name="serialNumber">The serial number of the class object.</param>
        /// <param name="power">The power of the class object.</param>
        public VehicleModel (EngineType engineType, string serialNumber, double power)
        {
            EngineType = engineType;
            SerialNumber = serialNumber;
            Power = power;
        }
    }
}
