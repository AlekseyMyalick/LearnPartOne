using System;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a scooter.
    /// </summary>
    [Serializable]
    public class Scooter : Vehicle 
    {
        /// <summary>
        /// Represents the presence of a stroller.
        /// </summary>
        public bool IsSidecar { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Scooter() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a Scooter-type object.</param>
        /// <param name="chassis">Chassis of a Scooter-type object.</param>
        /// <param name="transmission">Transmission of a Scooter-type object.</param>
        /// <param name="isSidecar">Does the "Passenger car" type object have a stroller.</param>
        public Scooter (Engine engine, Chassis chassis, Transmission transmission, bool isSidecar)
            : base(engine, chassis, transmission)
        {
            IsSidecar = isSidecar;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Is sidecar: {IsSidecar}\n";
        }
    }
}
