using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class AddCommand : ICommand
    {
        private Car _car;

        public AddCommand(Car car)
        {
            this._car = car;
        }

        public void Execute()
        {
            Garage.GetGarage().Add(_car);
        }
    }
}
