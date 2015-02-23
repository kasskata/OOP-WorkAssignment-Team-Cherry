using System;
using System.Collections.Generic;
using System.Data;
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

                //try
                //{
                var result = ExecuteCommand(command);
                output.AppendLine(result);
                //}
                //catch (Exception e)
                //{
                //    output.AppendLine(e.Message);
                //}
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
                    result = ExecuteListCommand(argumentsAsString);
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

        private string ExecuteListCommand(string argumentsAsString)
        {
            var matches = Regex.Split(argumentsAsString, @"\W+");

            var result = new StringBuilder();

            if (matches.Length > 1)
            {
                switch (matches[1])
                {
                    case "type":
                        ProductType type;
                        Enum.TryParse(matches[2], out type);
                        result.AppendLine(store.List(type));
                        break;
                    case "name":
                        result.AppendLine(store.List(matches[2]));
                        break;
                }
            }
            else
            {
                result.AppendLine(store.List());
            }
            return result.ToString();
        }


        private string ParseAddCommand(string commandLine)
        {
            string result = string.Empty;

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

            const string pattern = @"(\w+);\s(\d+(?:\.\d+)?)\s(\w+);\s(\w+);\s(\d+(?:\.\d+)?)(?:;\s(\d+(?:\.\d+)?))?";
            var match = Regex.Match(argumentsAsString, pattern);
            var arguments = match.Groups
                .Cast<Group>()
                .Select(m => m.Value)
                .ToArray();

            return ExecuteAddProductCommand(arguments);
        }

        private string ParseAddRecipeCommand(string argumentsAsString)
        {
            argumentsAsString = argumentsAsString.Trim('(', ')');

            const string pattern = @"(?<name>\w+);\s(?<type>\w+)(?:;\s(?<preparingTime>\d+))?;\sproducts:\s(?<products>.+)";
            var match = Regex.Match(argumentsAsString, pattern);

            List<String> arguments = new List<string>();
            arguments.Add(match.Groups["name"].ToString());
            arguments.Add(match.Groups["type"].ToString());

            if (match.Groups["preparingTïme"].ToString() != "")
            {
                arguments.Add(match.Groups["preparingTime"].ToString());
            }

            var productsAsString = match.Groups["products"].ToString().Split(',');
            var productsCount = productsAsString.Length;

            var products = new List<IProduct>();

            for (int i = 0; i < productsCount; i++)
            {
                var productArguments = productsAsString[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var productName = productArguments[0];
                var productQuantity = double.Parse(productArguments[1]);
                var productUnitOfMeasurement = productArguments[2];
                var product = productFactory.CreateEatableProduct(productName, productQuantity,
                    ParseUnitOfMeasurement(productUnitOfMeasurement));
                products.Add(product);
            }

            return ExecuteAddRecipeCommand(arguments.ToArray(), products);
        }

        private string ExecuteAddRecipeCommand(string[] arguments, IList<IProduct> products)
        {
            IRecipe recipe;

            var name = arguments[0];
            var type = arguments[1];
            var preparingTime = arguments.Length == 3 ? int.Parse(arguments[2]) : 0;

            switch (type)
            {
                case "raw":
                    recipe = recipeFactory.CreateRawRecipe(name, preparingTime);
                    break;
                case "fried":
                    recipe = recipeFactory.CreateFriedRecipe(name, preparingTime);
                    break;
                case "boiled":
                    recipe = recipeFactory.CreateBoiledRecipe(name, preparingTime);
                    break;
                case "grilled":
                    recipe = recipeFactory.CreateRawRecipe(name, preparingTime);
                    break;
                case "drink":
                    recipe = recipeFactory.CreateDrinkableRecipe(name);
                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }
            cookBook.AddRecipe(recipe);

            return Messages.SuccessAddRecipe;
        }


        private string ExecuteAddProductCommand(string[] arguments)
        {
            var name = arguments[1];
            var quantity = double.Parse(arguments[2]);
            var unitOfMeasurementAsString = arguments[3];
            var typeAsString = arguments[4];
            var price = decimal.Parse(arguments[5]);

            IProduct product;

            UnitOfMeasurement units = ParseUnitOfMeasurement(unitOfMeasurementAsString);
            ProductType type = ParseProductType(typeAsString);

            const int MaxArgumentCount = 7;
            if (arguments[6] != string.Empty)
            {
                var calories = int.Parse(arguments[6]);
                product = productFactory.CreateEatableProduct(name, price, quantity, units, type, calories);
            }
            else
            {
                product = productFactory.CreateProduct(name, price, quantity, units, type);
            }

            store.AddProduct(product);

            return Messages.SuccessAddProduct;
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
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }

        }

        private ProductType ParseProductType(string type)
        {
            switch (type.ToLower())
            {
                case "beans":
                    return ProductType.Beans;
                case "dairy":
                    return ProductType.Dairy;
                case "meat":
                    return ProductType.Meat;
                case "other":
                    return ProductType.Other;
                case "pasta":
                    return ProductType.Pasta;
                case "plants":
                    return ProductType.Plants;
                case "spices":
                    return ProductType.Spices;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }
        }
    }
}
