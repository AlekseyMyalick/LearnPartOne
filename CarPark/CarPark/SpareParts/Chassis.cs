using System;

namespace CarPark
{
    [Serializable]
    public class Chassis
    {
        private double _permissibleLoad;

        public byte WheelsCount { get; set; }

        public string SerialNumber { get; set; }

        public double PermissibleLoad
        {
            get
            {
                return _permissibleLoad;
            }
            set
            {
                if (_permissibleLoad < 0)
                {
                    throw new ArgumentOutOfRangeException("The permissible load cannot be less than zero.");
                }
                else
                {
                    _permissibleLoad = value;
                }
            }
        }

        public Chassis () { }

        public Chassis (byte wheelsCount, string serialNumber, double permissibleLoad)
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
