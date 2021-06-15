using System.Collections.Generic;

namespace CarGarage.Basic
{
    /// <summary>
    /// Represents the Garage entity.
    /// </summary>
    public class Garage
    {
        /// <summary>
        /// Instance of the class.
        /// </summary>
        private static Garage _garage;

        private List<Car> _carGarage;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        private Garage()
        {
            _carGarage = new List<Car>();
        }

        /// <summary>
        /// A static method that controls access to the instance. 
        /// On first launch, it creates an instance. On subsequent launches, 
        /// it returns the previously created object.
        /// </summary>
        /// <returns>The only instance of the class.</returns>
        public static Garage GetGarage()
        {
            if (_garage == null)
            {
                _garage = new Garage();
            }

            return _garage;
        }
    }
}
