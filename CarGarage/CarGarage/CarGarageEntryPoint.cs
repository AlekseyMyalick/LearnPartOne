using System;
using CarGarage.Interfaces;
using CarGarage.Invokers;
using CarGarage.Helpers;
using CarGarage.Basic;

namespace CarGarage
{
    class CarGarageEntryPoint
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            CommandsParser commandsParser = new CommandsParser();
            string commandLine;

            while (true)
            {
                commandLine =  Console.ReadLine();
                ICommand command = commandsParser.GetCommand(commandLine.Split(' '));
                invoker.ExecuteCommand(command, Garage.GetGarage());
            }
        }
    }
}
