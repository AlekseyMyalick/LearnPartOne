using System.Collections.Generic;
using System.Linq;

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

        private static List<Car> _carGarage;

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

        /// <summary>
        /// Adds an instance of the Car class.
        /// </summary>
        /// <param name="car">An instance of the Car class.</param>
        public static void Add(Car car)
        {
            _carGarage.Add(car);
        }

        /// <summary>
        /// Counts the number of all cars in the garage.
        /// </summary>
        /// <returns>The number of all cars.</returns>
        public static int CountAll()
        {
            return _carGarage.Select(c => c.Number).Sum();
        }

        /// <summary>
        /// Counts the number of car brands in the garage.
        /// </summary>
        /// <returns>Number of car brands.</returns>
        public static int CountTypes()
        {
            return _carGarage.GroupBy(c => c.Brand).Count();
        }

        /// <summary>
        /// Calculates the average cost of a car in the garage.
        /// </summary>
        /// <returns>The average cost of the car.</returns>
        public static decimal AveragePrice()
        {
            return _carGarage.Select(c => c.OnesCost * c.Number).Sum() / CountAll();
        }

        /// <summary>
        /// Calculates the average cost of each brand of cars in the garage.
        /// </summary>
        /// <param name="brand">Car brand.</param>
        /// <returns>Average cost of cars of each brand.</returns>
        public static decimal AveragePriceType(string brand)
        {
            return _carGarage.Where(c => c.Brand == brand).Select(c => c.OnesCost * c.Number).Sum()
                / _carGarage.Where(c => c.Brand == brand).Select(c => c.Number).Sum();
        }
    }
}
