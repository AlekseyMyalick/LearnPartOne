using System;
using CarGarage.Invokers;
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

        private Invoker _invoker;

        /// <summary>
        /// Initializes the fields of an instance of the class.
        /// </summary>
        /// <param name="invoker">Invoker.</param>
        public CommandsParser(Invoker invoker)
        {
            _invoker = invoker;
        }

        /// <summary>
        /// Call the method depending on the entered request.
        /// </summary>
        /// <param name="args">Command.</param>
        public void CommandExecute(string[] args)
        {
            switch (args[0])
            {
                case "add":
                    AddCommandExecute(args);
                    break;
                case "count":
                    CountCommandsExecute(args);
                    break;
                case "average":
                    AverageCommandsExecute(args);
                    break;
                case "exit":
                    _invoker.ExecuteCommand(new ExitCommand());
                    break;
                default:
                    Console.WriteLine(messageMissingCommand);
                    break;
            }
        }

        /// <summary>
        /// Calls commands wich first word is "count".
        /// </summary>
        /// <param name="args">Command.</param>
        private void CountCommandsExecute(string[] args)
        {
            switch (args[1])
            {
                case "types":
                    _invoker.ExecuteCommand(new CountTypesCommand());
                    break;
                case "all":
                    _invoker.ExecuteCommand(new CountAllCommand());
                    break;
                default:
                    Console.WriteLine(messageMissingCommand);
                    break;
            }
        }

        /// <summary>
        /// Calls commands which first word is "average".
        /// </summary>
        /// <param name="args">Command.</param>
        private void AverageCommandsExecute(string[] args)
        {
            switch (args[1])
            {
                case "price":
                    AveragePriceCommandsExecute(args);
                    break;
                default:
                    Console.WriteLine(messageMissingCommand);
                    break;
            }
        }

        /// <summary>
        /// Calls commands whose first word is "average", depending on the arguments passed.
        /// </summary>
        /// <param name="args">Command.</param>
        private void AveragePriceCommandsExecute(string[] args)
        {
            if (args.Length > 2)
            {
                _invoker.ExecuteCommand(new AveragePriceTypeCommand(args[2]));
            }
            else
            {
                _invoker.ExecuteCommand(new AveragePriceCommand());
            }
        }

        /// <summary>
        /// Calls the command the first word of which is "add".
        /// </summary>
        /// <param name="args">Command.</param>
        private void AddCommandExecute(string[] args)
        {
            Garage.Add(new Car(args[1], args[2], int.Parse(args[3]), decimal.Parse(args[4])));
        }
    }
}
