using System;
using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the AveragePriceType command.
    /// </summary>
    public class AveragePriceTypeCommand : ICommand
    {
        /// <summary>
        /// Car brand for calculating the average price.
        /// </summary>
        private string _brand;

        /// <summary>
        /// Initialization of the fields of the instance of the class.
        /// </summary>
        /// <param name="brand">Car brand for calculating the average price.</param>
        public AveragePriceTypeCommand(string brand)
        {
            this._brand = brand;
        }

        /// <summary>
        /// Executes the AveragePriceType command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            Console.WriteLine(garage.GetAveragePriceType(_brand));
        }
    }
}
