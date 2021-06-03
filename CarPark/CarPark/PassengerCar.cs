namespace CarPark
{
    class PassengerCar : Vehicle
    {
        public int DoorsCount { get; set; }

        public PassengerCar (Engine engine, Chassis chassis, Transmission transmission, int doorsCount) 
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
