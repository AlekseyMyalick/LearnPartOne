using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class CountAllCommand : ICommand
    {
        public void Execute()
        {
            System.Console.WriteLine(Garage.CountAll());
        }
    }
}
