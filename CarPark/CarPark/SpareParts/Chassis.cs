using System;

namespace CarPark
{
    /// <summary>
    /// Represents the entity defining the chassis.
    /// </summary>
    [Serializable]
    public class Chassis
    {
        /// <summary>
        /// Potential load, measured in tonnes.
        /// </summary>
        private double _permissibleLoad;

        /// <summary>
        /// Represents the number of wheels.
        /// </summary>
        public byte WheelsCount { get; set; }

        /// <summary>
        /// Represents the serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Represents the permissible load, cannot be less than zero, measured in tons.
        /// </summary>
        public double PermissibleLoad
        {
            get
            {
                return _permissibleLoad;
            }
            set
            {
                if (_permissibleLoad < 0)
                {
                    throw new ArgumentOutOfRangeException("The permissible load cannot be less than zero.");
                }
                else
                {
                    _permissibleLoad = value;
                }
            }
        }

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Chassis () { }

        /// <summary>
        /// Initializes the fields of the class object.
        /// </summary>
        /// <param name="wheelsCount">Number of wheels of an object of the Chassis type.</param>
        /// <param name="serialNumber">Serial number of the object type Chassis.</param>
        /// <param name="permissibleLoad">Permissible load of an object of the Chassis type.</param>
        public Chassis (byte wheelsCount, string serialNumber, double permissibleLoad)
        {
            WheelsCount = wheelsCount;
            SerialNumber = serialNumber;
            PermissibleLoad = permissibleLoad;
        }

        /// <summary>
        /// Returns a string describing the current object.
        /// </summary>
        /// <returns>A string describing the current object.</returns>
        public override string ToString()
        {
            return $"Wheels count: {WheelsCount} \nSerial number: {SerialNumber} \nPermissible load: {PermissibleLoad} tons \n";
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with the given instance.</param>
        /// <returns>True if obj is an instance of type Chassis and is equal 
        /// to the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Chassis chassis = obj as Chassis;

            if (chassis == null)
            {
                return false;
            }

            return WheelsCount == chassis.WheelsCount &&
                SerialNumber == chassis.SerialNumber &&
                PermissibleLoad.CompareTo(chassis.PermissibleLoad) == 0;
        }

        /// <summary>
        /// Determines whether the specified object instances are considered equal.
        /// </summary>
        /// <param name="objA">The first of the compared objects.</param>
        /// <param name="objB">The second of the compared objects.</param>
        /// <returns>true if the specified objects are equal; otherwise, false,
        /// if both objA and objB are null, the method returns true.</returns>
        public static bool Equals(object objA, object objB)
        {
            if (objA == objB)
            {
                return true;
            }

            if (objA == null || objB == null)
            {
                return false;
            }

            return objA.Equals(objB);
        }
    }
}
