using CarGarage.Interfaces;
using CarGarage.Basic;

namespace CarGarage.Commands
{
    public class CountTypesCommand : ICommand
    {
        public void Execute()
        {
            System.Console.WriteLine(Garage.GetGarage().GetCountTypes());
        }
    }
}
