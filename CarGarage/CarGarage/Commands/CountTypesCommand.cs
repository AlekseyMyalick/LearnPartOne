using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    class CountTypesCommand : ICommand
    {
        public void Execute()
        {
            Garage.CountTypes();
        }
    }
}
