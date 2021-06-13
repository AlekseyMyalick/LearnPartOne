using System;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a transmission.
    /// </summary>
    [Serializable]
    public class Transmission
    {
        /// <summary>
        /// Represents the type of transmission.
        /// </summary>
        public TransmissionType Type { get; set; }

        /// <summary>
        /// Represents the number of transfers.
        /// </summary>
        public byte GearsNumber { get; set; }

        /// <summary>
        /// Represents the manufacturer.
        /// </summary>
        public TransmissionManufacturers Manufacturer { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Transmission() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="type">Type of object of type Transmission.</param>
        /// <param name="gearsNumber">The number of gears of the Transmission type object.</param>
        /// <param name="manufacturer">The manufacturer of the transmission type object.</param>
        public Transmission (TransmissionType type, byte gearsNumber, TransmissionManufacturers manufacturer)
        {
            Type = type;
            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return $"Type: {Type}\nGears number: {GearsNumber}\nManufacturer: {Manufacturer}\n";
        }
    }
}
