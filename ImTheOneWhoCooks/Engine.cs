using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ImTheOneWhoCooks.Contracts;
using ImTheOneWhoCooks.Enums;
using ImTheOneWhoCooks.Models;
using ImTheOneWhoCooks.Models.Products;

namespace ImTheOneWhoCooks
{
    public class Engine
    {
        private readonly StringBuilder output;
        private readonly ProductFactory factory;
        private readonly CookBook cookBook;
        private readonly StoreHouse store;

        public Engine()
        {
            this.output = new StringBuilder();
            this.factory = new ProductFactory();
            this.store = new StoreHouse();
            this.cookBook = new CookBook();
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command != null && command.ToLower() == "end")
                {
                    Console.WriteLine(output.ToString().Trim());
                    break;
                }

                try
                {
                    var result = ExecuteCommand(command);
                    output.AppendLine(result);
                }
                catch (Exception e)
                {
                    output.AppendLine(e.Message);
                }
            }
        }

        private string ExecuteCommand(string commandLine)
        {
            string result = "";

            string command;
            string argumentsAsString;
            getEverythingAfterFirstWord(commandLine, out command, out argumentsAsString);

            switch (command)
            {
                case "Add":
                    result = ParseAddCommand(argumentsAsString);
                    break;
                case "List":

                    break;
                case "Cook":

                    break;
                case "Report":

                    break;
                case "HowMuch":

                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }

            return result;
        }


        private string ParseAddCommand(string commandLine)
        {
            string result = "";

            string command;
            string argumentsAsString;
            getEverythingAfterFirstWord(commandLine, out command, out argumentsAsString);

            switch (command)
            {
                case "product":
                    result = ParseAddProductCommand(argumentsAsString);
                    break;
                case "recipe":
                    result = ParseAddRecipeCommand(argumentsAsString);
                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }

            return result;
        }

        private string ParseAddProductCommand(string argumentsAsString)
        {
            argumentsAsString = argumentsAsString.Trim('(', ')');

            var pattern = @"(\w+);\s(\d+(?:\.\d+)?)\s(\w+);\s(\w+);\s(\d+(?:\.\d+)?)";
            var match = Regex.Match(argumentsAsString, pattern);
            var arguments = match.Groups
                .Cast<Group>()
                .Select(m => m.Value)
                .ToArray();

            return ExecuteAddProductCommand(arguments);
        }

        private string ParseAddRecipeCommand(string argumentsAsString)
        {
            throw new NotImplementedException();
        }

        private string ExecuteAddProductCommand(string[] arguments)
        {
            var result = string.Empty;

            try
            {
                var name = arguments[1];
                var quantity = double.Parse(arguments[2]);
                var unitOfMeasurementAsString = arguments[3];
                var typeAsString = arguments[4];
                var price = decimal.Parse(arguments[5]);

                IProduct product;

                UnitOfMeasurement units;
                Enum.TryParse(unitOfMeasurementAsString, out units);

                ProductType type;
                Enum.TryParse(typeAsString, out type);

                const int MaxArgumentCount = 7;
                if (arguments.Length == MaxArgumentCount)
                {
                    var calories = int.Parse(arguments[6]);
                    product = factory.CreateEatableProduct(name, price, quantity, units, type, calories);
                }
                else
                {
                    product = factory.CreateProduct(name, price, quantity, units, type);
                }

                store.IsDuplicate(product);

                return result = Messages.SuccessAddProduct;
            }
            catch (Exception)
            {
                result = Messages.InvalidProductCommand;
                return result;
            }
        }

        private void getEverythingAfterFirstWord(string input, out string firstWord, out string textAfterFirstWord)
        {
            string pattern = "\\w+";
            var r = new Regex(pattern);
            var match = r.Match(input);
            firstWord = match.Value;
            var endOfCommandIndex = match.Index + match.Length;
            textAfterFirstWord = input.Substring(endOfCommandIndex).Trim();
        }

    }
}
