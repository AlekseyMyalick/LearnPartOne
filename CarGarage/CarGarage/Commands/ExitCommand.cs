using System;
using CarGarage.Interfaces;

namespace CarGarage.Commands
{
    public class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
