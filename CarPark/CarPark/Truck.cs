using System;

namespace CarPark
{
    [Serializable]
    public class Truck : Vehicle
    {
        private double _maxSpeed;

        public double MaxSpeed
        {
            get
            {
                return _maxSpeed;
            }
            set
            {
                if (_maxSpeed < 0)
                {
                    throw new ArgumentOutOfRangeException("The maximum speed cannot be less than zero.");
                }
                else
                {
                    _maxSpeed = value;
                }
            }
        }

        public Truck() { }

        public Truck (Engine engine, Chassis chassis, Transmission transmission, double maxSpeed)
            : base(engine, chassis, transmission)
        {
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return base.ToString() + $"Max speed: {MaxSpeed}\n";
        }
    }
}
