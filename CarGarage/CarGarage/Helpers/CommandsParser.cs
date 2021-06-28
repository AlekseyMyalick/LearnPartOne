using System;
using CarGarage.Interfaces;
using CarGarage.Basic;
using CarGarage.Commands;

namespace CarGarage.Helpers
{
    /// <summary>
    /// Class methods parse a string into a command.
    /// </summary>
    public class CommandsParser
    {
        /// <summary>
        /// The text of the message when there is no command entered.
        /// </summary>
        private static readonly string messageMissingCommand = "There is no such command.";

        /// <summary>
        /// Returns the command depending on the entered request.
        /// </summary>
        /// <param name="args">Command.</param>
        /// <returns>An object of type ICommand.</returns>
        public ICommand GetCommand(string[] args)
        {
            ICommand command;

            switch (args[0])
            {
                case "add":
                    command = GetAddCommand(args);
                    break;
                case "count":
                    command = GetCountCommand(args);
                    break;
                case "average":
                    command = GetAverageCommand(args);
                    break;
                case "exit":
                    command = new ExitCommand();
                    break;
                default:
                    command = null;
                    break;
            }

            if (command == null)
            {
                PrintMessageMissingCommand();
            }

            return command;
        }

        /// <summary>
        /// Returns the command wich first word is "count".
        /// </summary>
        /// <param name="args">Command.</param>
        /// <returns>An object of type ICommand.</returns>
        private ICommand GetCountCommand(string[] args)
        {
            if (args.Length != 2)
            {
                return null;
            }

            switch (args[1])
            {
                case "types":
                    return new CountTypesCommand();
                case "all":
                    return new CountAllCommand();
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the command which first word is "average".
        /// </summary>
        /// <param name="args">Command.</param>
        /// <returns>An object of type ICommand.</returns>
        private ICommand GetAverageCommand(string[] args)
        {
            if (args.Length == 1)
            {
                return null;
            }

            switch (args[1])
            {
                case "price":
                    return GetAveragePriceCommand(args);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the command which first word is "average", depending on the arguments passed.
        /// </summary>
        /// <param name="args">Command.</param>
        /// <returns>An object of type ICommand.</returns>
        private ICommand GetAveragePriceCommand(string[] args)
        {
            switch (args.Length)
            {
                case 2:
                    return new AveragePriceCommand();
                case 3:
                    return new AveragePriceTypeCommand(args[2]);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Returns the command the first word of which is "add".
        /// </summary>
        /// <param name="args">Command.</param>
        /// <returns>An object of type ICommand.</returns>
        private ICommand GetAddCommand(string[] args)
        {
            if (args.Length != 5)
            {
                return null;
            }

            if (!int.TryParse(args[3], out int number))
            {
                return null;
            }

            if (!decimal.TryParse(args[4], out decimal oneCost))
            {
                return null;
            }

            Car car = new Car(args[1], args[2], number, oneCost);

            return new AddCommand(car);
        }

        /// <summary>
        /// Prints a message about the absence of a command.
        /// </summary>
        private void PrintMessageMissingCommand()
        {
            Console.WriteLine(messageMissingCommand);
        }
    }
}
