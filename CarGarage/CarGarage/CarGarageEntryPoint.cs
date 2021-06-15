using System;
using CarGarage.Basic;
using CarGarage.Invokers;
using CarGarage.Helpers;

namespace CarGarage
{
    class CarGarageEntryPoint
    {
        static void Main(string[] args)
        {
            Garage garage = Garage.GetGarage();

            Invoker invoker = new Invoker();

            CommandsParser commandsParser = new CommandsParser(invoker);
            string commandLine;

            while (true)
            {
                commandLine =  Console.ReadLine();
                commandsParser.CommandExecute(commandLine.Split(' '));
            }
        }
    }
}
