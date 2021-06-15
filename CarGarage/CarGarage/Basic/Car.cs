namespace CarGarage.Basic
{
    /// <summary>
    /// Represents the Car entity.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Represents the brand of an instance of a class.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Represents the instance model of the class.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Represents the number of cars with the specified brand and model.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Represents the cost of one car with the specified brand and model.
        /// </summary>
        public decimal OnesCost { get; set; }

        /// <summary>
        /// Initialization of the fields of the instance of the class.
        /// </summary>
        /// <param name="brand">The brand of an instance of a class</param>
        /// <param name="model">The instance model of the class.</param>
        /// <param name="number">The number of cars with the specified brand and model.</param>
        /// <param name="oneCost">The cost of one car with the specified brand and model.</param>
        public Car(string brand, string model, int number, decimal oneCost)
        {
            Brand = brand;
            Model = model;
            Number = number;
            OnesCost = oneCost;
        }

    }
}
