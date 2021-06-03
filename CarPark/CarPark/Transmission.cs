namespace CarPark
{
    public class Transmission
    {
        public TransmissionTypeEnum Type { get; set; }

        public int GearsNumber { get; set; }

        public TransmissionManufacturersEnum Manufacturer { get; set; }

        public Transmission (TransmissionTypeEnum type, int gearsNumber, TransmissionManufacturersEnum manufacturer)
        {
            Type = type;
            GearsNumber = gearsNumber;
            Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return $"Type: {Type}\n Gears number: {GearsNumber}\n Manufacturer: {Manufacturer} \n";
        }
    }
}
