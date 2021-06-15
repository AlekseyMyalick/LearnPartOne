using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class CountTypesCommand : ICommand
    {
        public void Execute()
        {
            Garage.CountTypes();
        }
    }
}
