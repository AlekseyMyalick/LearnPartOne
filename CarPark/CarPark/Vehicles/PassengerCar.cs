using System;

namespace CarPark
{
    [Serializable]
    public class PassengerCar : Vehicle
    {
        public byte DoorsCount { get; set; }

        public PassengerCar() { }

        public PassengerCar (Engine engine, Chassis chassis, Transmission transmission, byte doorsCount) 
            : base(engine, chassis, transmission)
        {
            DoorsCount = doorsCount;
        }

        public override string ToString()
        {
            return base.ToString() + $"Doors count: {DoorsCount}\n";
        }
    }
}
