﻿using System;
using CarPark.Exceptions;

namespace CarPark
{
    /// <summary>
    /// Represents an entity that defines a passenger car.
    /// </summary>
    [Serializable]
    public class PassengerCar : Vehicle
    {
        /// <summary>
        /// Maximum number of doors.
        /// </summary>
        private const byte _maxDoorsNumber = 4;

        /// <summary>
        /// The minimum number of doors.
        /// </summary>
        private const byte _minDoorsNumber = 2;

        /// <summary>
        /// Represents the number of doors.
        /// </summary>
        public byte DoorsCount { get; set; }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public PassengerCar() { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="engine">The engine of a PassengerCar-type object.</param>
        /// <param name="chassis">Chassis of a PassengerCar-type object.</param>
        /// <param name="transmission">Transmission of a PassengerCar-type object.</param>
        /// <param name="doorsCount">Number of doors of a PassengerCar-type object.</param>
        public PassengerCar (Engine engine, Chassis chassis, Transmission transmission, byte doorsCount) 
            : base(engine, chassis, transmission)
        {
            DoorsCount = doorsCount;

            if (!IsValidPassengerCar())
            {
                throw new InitializationException("Unable to initialize the PassengerCar.");
            }
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return base.ToString() + $"Doors count: {DoorsCount}\n";
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type PassengerCar and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            PassengerCar passengerCar = obj as PassengerCar;

            if (passengerCar == null)
            {
                return false;
            }

            return base.Equals(passengerCar) &&
                DoorsCount == passengerCar.DoorsCount;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code as a 32-bit signed integer.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode() + DoorsCount;
        }

        /// <summary>
        /// Whether the field values of the class object are valid.
        /// </summary>
        /// <returns>True if the values are valid, otherwise false.</returns>
        private bool IsValidPassengerCar()
        {
            return IsValidVehicle() && DoorsCount >= _minDoorsNumber && DoorsCount <= _maxDoorsNumber; 
        }
    }
}
