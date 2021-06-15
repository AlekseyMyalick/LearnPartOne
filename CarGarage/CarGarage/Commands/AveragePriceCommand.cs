using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    class AveragePriceCommand : ICommand
    {
        public void Execute()
        {
            Garage.AveragePrice();
        }
    }
}
