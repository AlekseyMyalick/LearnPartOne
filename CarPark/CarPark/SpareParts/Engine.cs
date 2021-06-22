using System;

namespace CarPark
{
    /// <summary>
    /// Represents the entity that defines the engine.
    /// </summary>
    [Serializable]
    public class Engine
    {
        /// <summary>
        /// Represents power.
        /// </summary>
        public double Power { get; set; }

        /// <summary>
        /// Represents volume.
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Represents the type of engine.
        /// </summary>
        public EngineType Type { get; set; }

        /// <summary>
        /// Represents the serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Engine() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="power">Power of an object of type Engine.</param>
        /// <param name="volume">The volume of the Engine type object.</param>
        /// <param name="engineType">Engine type of the Engine type object.</param>
        /// <param name="serialNumber">Serial number of the engine type object</param>
        public Engine(double power, double volume, EngineType engineType, string serialNumber)
        {
            Power = power;
            Volume = volume;
            Type = engineType;
            SerialNumber = serialNumber;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return $"Power: {Power} hp \nVolume: {Volume} l \nEngine type: {Type} \nSerial number: {SerialNumber}\n";
        }
    }
}
