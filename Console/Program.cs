using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandRegex = new Regex("(create|login|deposit|withdraw|balance|history|logout|exit|help)");

            Commands commands = new Commands();

            while (true)
            {
                Console.Write("{0}>", commands.bank.LoggedInAccount == null ? "" : commands.bank.LoggedInAccount.Name);

                string input = Console.ReadLine();
                var arg = commandRegex.Match(input);
                if (!arg.Success) {
                    Console.WriteLine("Invalid command.");
                    commands.Help();
                    continue;
                }

                var command = arg.Groups[0].ToString();

                if (command == "exit")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                command = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(command);

                try
                {
                    commands.GetType().GetMethod(command).Invoke(commands, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }
    }
}
