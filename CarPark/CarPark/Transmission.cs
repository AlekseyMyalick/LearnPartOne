using System;

namespace CarPark
{
    [Serializable]
    public class Transmission
    {
        public TransmissionType Type { get; set; }

        public byte GearsNumber { get; set; }

        public TransmissionManufacturers Manufacturer { get; set; }

        public Transmission() { }

        public Transmission (TransmissionType type, byte gearsNumber, TransmissionManufacturers manufacturer)
        {
            Type = type;
            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"Type: {Type}\nGears number: {GearsNumber}\nManufacturer: {Manufacturer}\n";
        }
    }
}
