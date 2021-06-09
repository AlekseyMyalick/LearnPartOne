using System;

namespace CarPark
{
    [Serializable]
    public class Bus : Vehicle
    {
        public byte SeatsCount { get; set; }

        public Bus() { }

        public Bus (Engine engine, Chassis chassis, Transmission transmission, byte seatsCount)
            : base(engine, chassis, transmission)
        {
            SeatsCount = seatsCount;
        }

        public override string ToString()
        {
            return base.ToString() + $"Seats count: {SeatsCount}\n";
        }
    }
}
