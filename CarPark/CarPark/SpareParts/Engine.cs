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

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type Engine and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var engine = obj as Engine;

            return Power.CompareTo(engine.Power) == 0 &&
                Volume.CompareTo(engine.Volume) == 0 &&
                Type == engine.Type &&
                SerialNumber == engine.SerialNumber;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code as a 32-bit signed integer.</returns>
        public override int GetHashCode()
        {
            return (int)Power + (int)Volume + (int)Type + SerialNumber.Length;
        }
    }
}
