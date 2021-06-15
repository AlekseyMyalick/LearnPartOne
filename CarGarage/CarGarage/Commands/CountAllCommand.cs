using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class CountAllCommand : ICommand
    {
        public void Execute()
        {
            Garage.CountAll();
        }
    }
}
