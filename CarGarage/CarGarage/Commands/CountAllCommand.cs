using System;
using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the CountAll command.
    /// </summary>
    public class CountAllCommand : ICommand
    {
        /// <summary>
        /// Executes the CountAll command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            Console.WriteLine(garage.GetCountAll());
        }
    }
}
