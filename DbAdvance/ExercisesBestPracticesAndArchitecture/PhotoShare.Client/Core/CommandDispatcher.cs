namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Commands;
    using Models;
    using Utilities;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            if (commandParameters == null || commandParameters.Length < 1)
            {
                return Constants.InvalidCommand;
            }

            var commandName = commandParameters[0] + Constants.CommandSufix;
            var type = Assembly
                .GetAssembly(typeof(Command))
                .GetTypes()
                .Where(c => c.IsClass && !c.IsAbstract && c.IsSubclassOf(typeof(Command)))
                .FirstOrDefault(c => c.Name == commandName);

            if (type == null)
            {
                throw new InvalidOperationException($"Command {commandName} not valid!");
            }


            string[] data = null;
            if (commandParameters.Length > 1)
            {
                data = commandParameters.Skip(1).ToArray();
            }

            var command = (Command)Activator.CreateInstance(type);
            return command.Execute(data);
        }
    }
}
