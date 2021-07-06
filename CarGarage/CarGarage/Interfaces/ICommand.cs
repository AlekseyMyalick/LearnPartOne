using CarGarage.Basic;

namespace CarGarage.Interfaces
{
    /// <summary>
    /// Declares a method for executing commands.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes command.
        /// </summary>
        /// <param name="garage">Database for command execution.</param>
        void Execute(Garage garage);
    }
}
