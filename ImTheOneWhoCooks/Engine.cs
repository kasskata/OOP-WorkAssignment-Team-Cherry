using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ImTheOneWhoCooks
{
    public class Engine
    {
        private StringBuilder output;

        public Engine()
        {
            output = new StringBuilder();
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
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

                    break;
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }

            return result;
        }

        private string ParseAddProductCommand(string argumentsAsString)
        {
            argumentsAsString = argumentsAsString.Trim(new char[] {'(', ')'});

            var pattern = "(\\w+);\\s(\\d+(?:\\.\\d+)?)\\s(\\w+);\\s(\\w+);\\s(\\d+(?:\\.\\d+)?)";
            var match = Regex.Match(argumentsAsString, pattern);
            var arguments = match.Groups
                .Cast<Group>()
                .Select(m => m.Value)
                .ToArray();

            return ExecuteAddProductCommand(arguments);
        }

        private string ExecuteAddProductCommand(string[] arguments)
        {
            var name = arguments[1];
            var quantity = arguments[2];
            var unitOfMeasurementAsString = arguments[3];
            var typeAsString = arguments[4];
            var price = arguments[5];

            return String.Join(", ", arguments);
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
