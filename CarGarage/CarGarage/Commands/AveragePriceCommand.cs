using System;
using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the AveragePrice command.
    /// </summary>
    public class AveragePriceCommand : ICommand
    {
        /// <summary>
        /// Executes the AveragePrice command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            Console.WriteLine(garage.GetAveragePrice());
        }
    }
}
