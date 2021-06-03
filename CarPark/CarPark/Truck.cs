namespace CarPark
{
    public class Truck : Vehicle
    {
        public double MaxSpeed { get; set; }

        public Truck(Engine engine, Chassis chassis, Transmission transmission, double maxSpeed)
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
