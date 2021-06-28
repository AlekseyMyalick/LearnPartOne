using System;
using CarPark.Exceptions;

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

            if (!IsValidScooter())
            {
                throw new InitializationException("Unable to initialize the Scooter.");
            }
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Is sidecar: {IsSidecar}\n";
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type Scooter and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Scooter scooter = obj as Scooter;

            if (scooter == null)
            {
                return false;
            }

            return base.Equals(scooter) &&
                IsSidecar == scooter.IsSidecar;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code as a 32-bit signed integer.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + (IsSidecar ? 1 : 0);
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        private bool IsValidScooter()
        {
            return IsValidVehicle();
        }
    }
}
