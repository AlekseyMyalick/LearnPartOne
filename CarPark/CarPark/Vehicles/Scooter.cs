using System;

namespace CarPark
{
    [Serializable]
    public class Scooter : Vehicle 
    {
        public bool IsSidecar { get; set; }

        public Scooter() { }

        public Scooter (Engine engine, Chassis chassis, Transmission transmission, bool isSidecar)
            : base(engine, chassis, transmission)
        {
            IsSidecar = isSidecar;
        }

        public override string ToString()
        {
            return base.ToString() + $"Is sidecar: {IsSidecar}\n";
        }
    }
}
