﻿using System;
using CarPark.Exceptions;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a bus.
    /// </summary>
    [Serializable]
    public class Bus : Vehicle
    {
        /// <summary>
        /// Maximum number of seats.
        /// </summary>
        private const byte _maxSeatsNumber = 50;

        /// <summary>
        /// Represents the number of seats.
        /// </summary>
        public byte SeatsCount { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Bus() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a Bus-type object.</param>
        /// <param name="chassis">Chassis of a Bus-type object.</param>
        /// <param name="transmission">Transmission of a Bus-type object.</param>
        /// <param name="seatsCount">The number of seats of the object of the Bus type.</param>
        public Bus (Engine engine, Chassis chassis, Transmission transmission, byte seatsCount)
            : base(engine, chassis, transmission)
        {
            SeatsCount = seatsCount;

            if (!IsValidBus())
            {
                throw new InitializationException("Unable to initialize the Bus.");
            }
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Seats count: {SeatsCount}\n";
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type Bus and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Bus bus = obj as Bus;

            if (bus == null)
            {
                return false;
            }

            return base.Equals(bus) &&
                SeatsCount == bus.SeatsCount;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code as a 32-bit signed integer.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + SeatsCount;
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        private bool IsValidBus()
        {
            return IsValidVehicle() && SeatsCount <= _maxSeatsNumber;
        }
    }
}
