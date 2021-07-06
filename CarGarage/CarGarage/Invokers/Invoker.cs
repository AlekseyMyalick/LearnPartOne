using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Invokers
{
    /// <summary>
    /// Represents a class whose methods
    /// are invoked by commands
    /// </summary>
    public class Invoker
    {
        /// <summary>
        /// An instance of the ICommand interface.
        /// </summary>
        private ICommand _command;

        /// <summary>
        /// Executes the given command.
        /// </summary>
        /// <param name="command">Command to execute.</param>
        /// <param name="garage">Database for command execution.</param>
        public void ExecuteCommand(ICommand command, Garage garage)
        {
            if (command == null)
            {
                return;
            }

            _command = command;

            this._command.Execute(garage);
        }
    }
}
