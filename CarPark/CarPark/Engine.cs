namespace CarPark
{
    public class Engine
    {
        public double Power { get; set; }

        public double Volume { get; set; }

        public EngineTypeEnum EngineType { get; set; }

        public string SerialNumber { get; set; }

        public Engine(double power, double volume, EngineTypeEnum engineType, string serialNumber)
        {
            Power = power;
            Volume = volume;
            EngineType = EngineType;
            SerialNumber = serialNumber;
        }

        public override string ToString()
        {
            return $"Power: {Power} hp \nVolume: {Volume} l \nEngine type: {EngineType} \nSerial number: {SerialNumber}\n";
        }
    }
}
