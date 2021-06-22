using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class AveragePriceCommand : ICommand
    {
        public void Execute()
        {
            System.Console.WriteLine(Garage.GetAveragePrice());
        }
    }
}
