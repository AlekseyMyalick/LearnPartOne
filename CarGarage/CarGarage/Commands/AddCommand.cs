using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    /// <summary>
    /// Represents the method that executes the Add command.
    /// </summary>
    public class AddCommand : ICommand
    {
        /// <summary>
        /// An instance of the class to add.
        /// </summary>
        private Car _car;

        /// <summary>
        /// Initialization of the fields of the instance of the class.
        /// </summary>
        /// <param name="car">An instance of the class to add.</param>
        public AddCommand(Car car)
        {
            this._car = car;
        }

        /// <summary>
        /// Executes the Add command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        public void Execute(Garage garage)
        {
            garage.Add(_car);
        }
    }
}
