using CarGarage.Interfaces;

namespace CarGarage.Invokers
{
    public class Invoker
    {
        private ICommand _command;

        public void ExecuteCommand(ICommand command)
        {
            _command = command;

            this._command.Execute();
        }
    }
}
