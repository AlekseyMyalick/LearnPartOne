using System;
using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the CountTypes command.
    /// </summary>
    public class CountTypesCommand : ICommand
    {
        /// <summary>
        /// Executes the CountTypes command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            Console.WriteLine(garage.GetCountTypes());
        }
    }
}
