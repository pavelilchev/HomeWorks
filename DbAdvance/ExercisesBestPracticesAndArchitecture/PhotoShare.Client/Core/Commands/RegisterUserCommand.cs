namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Utilities;

    public class RegisterUserCommand : Command
    {
        // RegisterUser <username> <password> <repeat-password> <email>
        public override string Execute(string[] data)
        {
            if (data.Length != 4)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name.Replace(Constants.CommandSufix, "")} not valid!");
            }

            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (context.Users.Any(u => u.Username == user.Username))
                {
                    throw new InvalidOperationException($"Username {username} is already taken!");
                }

                if (password != repeatPassword)
                {
                    throw new ArgumentException("Passwords do not match!");
                }

                context.Users.Add(user);
                context.SaveChanges();
            }

            return "User " + user.Username + " was registered successfully!";
        }
    }
}
