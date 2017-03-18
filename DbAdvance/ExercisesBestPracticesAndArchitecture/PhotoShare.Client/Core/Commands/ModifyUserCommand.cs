namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Models;
    using Utilities;

    public class ModifyUserCommand : Command
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public override string Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username = data[0];
            string property = data[1];
            string newValue = data[2];


            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user =
                    context.Users.Include(u => u.BornTown)
                        .Include(u => u.CurrentTown)
                        .FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User {username} not found!");
                }

                if (Engine.User == null || Engine.User.Username != user.Username)
                {
                    throw new InvalidOperationException("Invalid credentials!");
                }

                if (property != "Password" && property != "BornTown" && property != "CurrentTown")
                {
                    throw new ArgumentException($"Property {property} not supported!");
                }

                string result = string.Empty;
                result = ChangePassword(property, newValue, user, context, result);

                result = ChangeBornTown(property, context, newValue, user, result);

                result = ChangeCurrentTown(property, context, newValue, user, result);

                return result;
            }
        }

        private static string ChangeCurrentTown(string property, PhotoShareContext context, string newValue, User user,
            string result)
        {
            if (property == "CurrentTown")
            {
                var town = context.Towns.FirstOrDefault(t => t.Name == newValue);
                if (town == null)
                {
                    throw new ArgumentException($@"Value {newValue} not valid. 
Town {newValue} not found!");
                }

                user.CurrentTown = town;
                context.SaveChanges();
                result = $"User {user.Username} {property} is {newValue}.";
            }

            return result;
        }

        private static string ChangeBornTown(string property, PhotoShareContext context, string newValue, User user,
            string result)
        {
            if (property == "BornTown")
            {
                var town = context.Towns.FirstOrDefault(t => t.Name == newValue);
                if (town == null)
                {
                    throw new ArgumentException($@"Value {newValue} not valid. 
Town {newValue} not found!");
                }

                user.BornTown = town;
                context.SaveChanges();
                result = $"User {user.Username} {property} is {newValue}.";
            }

            return result;
        }

        private static string ChangePassword(string property, string newValue, User user, PhotoShareContext context,
            string result)
        {
            if (property == "Password")
            {
                string passPatt = @"^(?=.*?[a-z])(?=.*?[0-9]).{2,}";
                if (!Regex.IsMatch(newValue, passPatt))
                {
                    throw new ArgumentException($@"Value {newValue} not valid. 
Invalid Password");
                }

                user.Password = newValue;
                context.SaveChanges();
                result = $"User {user.Username} {property} is {newValue}.";
            }

            return result;
        }
    }
}