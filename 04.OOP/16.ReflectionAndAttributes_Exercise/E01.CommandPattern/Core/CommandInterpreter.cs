using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] userInput = args.Split();

            string commandName = userInput[0];
            string[] commandArgs = userInput.Skip(1).ToArray();

            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command");

            if (type == null)
            {
                throw new InvalidOperationException("Missing command");
            }

            Type commandInterface = type.GetInterface("ICommand");

            if (commandInterface == null)
            {
                throw new InvalidOperationException("Not a command");
            }

            var command = Activator.CreateInstance(type) as ICommand;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
