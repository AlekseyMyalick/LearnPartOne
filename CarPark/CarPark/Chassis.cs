namespace CarPark
{
    public class Chassis
    {
        public int WheelsCount { get; set; }

        public string SerialNumber { get; set; }

        public double PermissibleLoad { get; set; }

        public Chassis (int wheelsCount, string serialNumber, double permissibleLoad)
        {
            WheelsCount = wheelsCount;
            SerialNumber = serialNumber;
            PermissibleLoad = permissibleLoad;
        }

        public override string ToString()
        {
            return $"Wheels count: {WheelsCount} \nSerial number: {SerialNumber} \nPermissible load: {PermissibleLoad} tons \n";
        }
    }
}
