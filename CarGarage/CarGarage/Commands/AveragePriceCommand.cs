using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class AveragePriceCommand : ICommand
    {
        public void Execute()
        {
            Garage.AveragePrice();
        }
    }
}
