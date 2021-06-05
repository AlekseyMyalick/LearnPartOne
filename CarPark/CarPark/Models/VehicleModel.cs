using System;

namespace CarPark.Models
{
    [Serializable]
    public class VehicleModel
    {
        public EngineType EngineType { get; set; }

        public string SerialNumber { get; set; }

        public double Power { get; set; }

        public VehicleModel() { }

        public VehicleModel (EngineType engineType, string serialNumber, double power)
        {
            EngineType = engineType;
            SerialNumber = serialNumber;
            Power = power;
        }
    }
}
