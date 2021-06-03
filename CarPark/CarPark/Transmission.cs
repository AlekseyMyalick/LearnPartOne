namespace CarPark
{
    public class Transmission
    {
        public TransmissionTypeEnum Type { get; set; }

        public byte GearsNumber { get; set; }

        public TransmissionManufacturersEnum Manufacturer { get; set; }

        public Transmission (TransmissionTypeEnum type, byte gearsNumber, TransmissionManufacturersEnum manufacturer)
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
