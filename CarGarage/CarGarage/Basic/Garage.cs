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
        public void Add(Car car)
        {
            _carGarage.Add(car);
        }

        /// <summary>
        /// Counts the number of all cars in the garage.
        /// </summary>
        /// <returns>The number of all cars.</returns>
        public int GetCountAll()
        {
            return _carGarage.Sum(c => c.Number);
        }

        /// <summary>
        /// Counts the number of car brands in the garage.
        /// </summary>
        /// <returns>Number of car brands.</returns>
        public int GetCountTypes()
        {
            return _carGarage.GroupBy(c => c.Brand).Count();
        }

        /// <summary>
        /// Calculates the average cost of a car in the garage.
        /// </summary>
        /// <returns>The average cost of the car.</returns>
        public decimal GetAveragePrice()
        {
            return _carGarage.Sum(c => c.OnesCost * c.Number) / GetCountAll();
        }

        /// <summary>
        /// Calculates the average cost of each brand of cars in the garage.
        /// </summary>
        /// <param name="brand">Car brand.</param>
        /// <returns>Average cost of cars of each brand.</returns>
        public decimal GetAveragePriceType(string brand)
        {
            if (_carGarage.Count(c => c.Brand == brand) == 0)
            {
                return 0;
            }

            var brendCars = _carGarage.GroupBy(c => c.Brand).Where(g => g.Key == brand).SelectMany(g => g);

            return brendCars.Sum(c => c.OnesCost * c.Number) / brendCars.Sum(c => c.Number);
        }
    }
}
