namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Utilities;

    public class AddTownCommand : Command
    {
        // AddTown <townName> <countryName>
        public override string Execute(string[] data)
        {
            if (data == null || data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (Engine.User == null)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                if (context.Towns.Any(t => t.Name == townName))
                {
                    throw new ArgumentException($"Town {townName} was already added!");
                }

                context.Towns.Add(town);
                context.SaveChanges();

                return townName + " was added successfully!";
            }
        }
    }
}
