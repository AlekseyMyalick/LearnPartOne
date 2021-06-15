using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class AveragePriceTypeCommand : ICommand
    {
        private string _brand;

        public AveragePriceTypeCommand(string brand)
        {
            this._brand = brand;
        }

        public void Execute()
        {
            Garage.AveragePriceType(_brand);
        }
    }
}
