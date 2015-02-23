using System;
using System.Collections.Generic;
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
        private readonly ProductFactory productFactory;
        private readonly RecipeFactory recipeFactory;
        private readonly CookBook cookBook;
        private readonly StoreHouse store;

        public Engine()
        {
            this.output = new StringBuilder();
            this.productFactory = new ProductFactory();
            recipeFactory = new RecipeFactory();
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

            const string pattern = @"(\w+);\s(\d+(?:\.\d+)?)\s(\w+);\s(\w+);\s(\d+(?:\.\d+)?)";
            var match = Regex.Match(argumentsAsString, pattern);
            var arguments = match.Groups
                .Cast<Group>()
                .Select(m => m.Value)
                .ToArray();

            return ExecuteAddProductCommand(arguments);
        }

        private string ParseAddRecipeCommand(string argumentsAsString)
        {
            argumentsAsString = argumentsAsString.Trim(new char[] { '(', ')' });

            const string pattern = @"(?<name>\w+);\s(?<type>\w+)(?:;\s(?<preparingTime>\d+))?;\sproducts:\s(?<products>.+)";
            var match = Regex.Match(argumentsAsString, pattern);
            var arguments = match.Groups
                .Cast<Group>()
                .Select(m => m.Value)
                .ToArray();

            const int MaxArgumentsCount = 5;

            var name = arguments[1];
            var type = arguments[2];
            var preparingTimeInMinutes = int.Parse(arguments[MaxArgumentsCount - 1]);
            var productsAsString = arguments[MaxArgumentsCount];

            var productsAndQuantityAsString = productsAsString.Split(',');
            var productsCount = productsAndQuantityAsString.Length;

            var products = new List<IProduct>();

            for (int i = 0; i < productsCount; i++)
            {
                var productArguments = productsAndQuantityAsString[i].Split(' ');
                var productName = productArguments[0];
                var productQuantity = double.Parse(productArguments[1]);
                var productUnitOfMeasurement = productArguments[2];
                var product = productFactory.CreateEatableProductWithoutPriceAndCalories(productName, productQuantity,
                    ParseUnitOfMeasurement(productUnitOfMeasurement), ParseProductType(type));
                products.Add(product);
            }

            return ExecuteAddRecipeCommand(arguments, products);
        }

        private string ExecuteAddRecipeCommand(string[] arguments, IList<IProduct> products)
        {


            // TODO 
            //var recipe = recipeFactory 
            return String.Join(", ", arguments);
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
                    product = productFactory.CreateEatableProduct(name, price, quantity, units, type, calories);
                }
                else
                {
                    product = productFactory.CreateProduct(name, price, quantity, units, type);
                }

                store.AddProduct(product);

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
            const string pattern = "\\w+";
            var r = new Regex(pattern);
            var match = r.Match(input);
            firstWord = match.Value;
            var endOfCommandIndex = match.Index + match.Length;
            textAfterFirstWord = input.Substring(endOfCommandIndex).Trim();
        }

        private UnitOfMeasurement ParseUnitOfMeasurement(string unit)
        {
            switch (unit)
            {
                case "ml":
                    return UnitOfMeasurement.Milliliters;
                case "g":
                    return UnitOfMeasurement.Grams;
                case "pcs":
                    return UnitOfMeasurement.Pieces;
                default:
                    throw new NotImplementedException();
            }

        }

        private ProductType ParseProductType(string type)
        {
            switch (type)
            {
                case "Beans":
                    return ProductType.Beans;
                case "Dairy":
                    return ProductType.Dairy;
                case "Meat":
                    return ProductType.Meat;
                case "Other":
                    return ProductType.Other;
                case "Pasta":
                    return ProductType.Pasta;
                case "Plants":
                    return ProductType.Plants;
                case "Spices":
                    return ProductType.Spices;
                default : 
                    throw  new NotImplementedException();
             }
        }
    }
}
