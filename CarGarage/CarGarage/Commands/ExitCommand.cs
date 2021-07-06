using System;
using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the Exit command.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// Executes the Exit command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            Environment.Exit(0);
        }
    }
}
